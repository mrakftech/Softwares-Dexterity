using System.Collections.ObjectModel;
using AutoMapper;
using Database;
using Domain.Entites.UserAccounts;
using Features.Contracts.Modules;
using Features.Respository;
using Microsoft.EntityFrameworkCore;
using Shared.Constants.Role;
using Shared.Helper;
using Shared.Requests.Auth;
using Shared.Requests.UserAccounts;
using Shared.Responses.UserAccounts;
using Shared.State;
using Shared.Wrapper;

namespace Services.Features.UserAccounts.Service;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(ApplicationDbContext context, IMapper mapper) : base(context)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<LoginResponse>> LoginAsync(LoginRequest request)
    {
        var userInDb = await _context.Users.Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Username == request.Username);

        if (userInDb is null)
        {
            return await Result<LoginResponse>.FailAsync("Invalid Credentials");
        }

        if (!userInDb.IsActive || userInDb.IsDeleted)
        {
            return await Result<LoginResponse>.FailAsync("user is deactivated. contact support.");
        }

        var isValid = SecurePasswordHasher.Verify(request.Password, userInDb.PasswordHash);

        if (!isValid) return await Result<LoginResponse>.FailAsync("Invalid Credentials");

        var response = new LoginResponse()
        {
            UserId = userInDb.Id,
            RoleName = userInDb.Role.Name,
            IsForceReset = userInDb.IsForceReset
        };
        ApplicationState.CurrentUser = response;
        return await Result<LoginResponse>.SuccessAsync("Login successfully.");
    }

    public async Task<ObservableCollection<UserResponse>> GetUsers()
    {
        var usersList = await _context.Users.Include(x => x.Role).Where(x => x.IsDeleted == false)
            .OrderByDescending(x => x.CreatedDate).ToListAsync();
        var users = _mapper.Map<ObservableCollection<UserResponse>>(usersList);
        return users;
    }

    public async Task<UserResponse> GetUser(Guid id)
    {
        var userInDb = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<UserResponse>(userInDb);
    }

    public async Task<IResult> SaveUser(CreateUserRequest request)
    {
        try
        {
            if (request.Id == Guid.Empty)
            {
                if (_context.Users.Any(x => x.Username == request.Username))
                {
                    return await Result.FailAsync("Username already exists.");
                }

                var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == request.UserRole);
                request.Id = Guid.NewGuid();
                request.RoleId = role.Id;
                request.ResetPasswordAt = Method.GetPasswordResetTime(request.ResetPassword);
                request.CreatedBy = ApplicationState.CurrentUser.UserId;
                var hashPassword = SecurePasswordHasher.Hash(request.Password);
                var user = _mapper.Map<User>(request);
                user.PasswordHash = hashPassword;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return await Result.SuccessAsync("User saved");
            }
            else
            {
                if (request.IsUpdatePassword)
                {
                    request.Password = SecurePasswordHasher.Hash(request.Password);
                }

                var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == request.UserRole);
                var userInDb = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
                request.RoleId = role.Id;
                request.ModifiedBy = ApplicationState.CurrentUser.UserId;
                request.ModifiedDate = DateTime.Today;
                userInDb = _mapper.Map(request, userInDb);
                _context.Users.Update(userInDb);
                await _context.SaveChangesAsync();
                return await Result.SuccessAsync("User saved");
            }
        }
        catch (Exception e)
        {
            return await Result.FailAsync(e.Message);
        }
    }

    public async Task<IResult> DeleteUser(Guid id)
    {
        var userInDb = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == id);
        if (userInDb.Role.Name == RoleConstants.AdministratorRole)
        {
            return await Result.FailAsync("Can't be delete admin user");
        }

        if (userInDb is null)
        {
            return await Result.FailAsync("User not found.");
        }

        userInDb.IsDeleted = true;
        await _context.SaveChangesAsync();
        return await Result.SuccessAsync("User has been deleted.");
    }

    public async Task<RoleResponse> GetUserRole(Guid roleId)
    {
        var roleInDb = await _context.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
        return _mapper.Map<RoleResponse>(roleInDb);
    }

    public async Task<Guid> GetRoleId(string name)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == name);
        return role.Id;
    }

    public void Logout()
    {
        ApplicationState.CurrentUser = null;
    }

    #region Permissions

    public async Task<ObservableCollection<PermissionResponse>> GetPermissions(Guid roleId, string module)
    {
        var permissions = await _context.PermissionClaims.Where(x => x.RoleId == roleId && x.ModuleName == module)
            .ToListAsync();
        var data = _mapper.Map<ObservableCollection<PermissionResponse>>(permissions);
        return data;
    }

    public async Task<IResult> UpdatePermissions(List<UpdatePermissionRequest> requests)
    {
        foreach (var request in requests)
        {
            var p = await _context.PermissionClaims.FirstOrDefaultAsync(x => x.Id == request.Id);
            p.Allowed = request.Value;
            await _context.SaveChangesAsync();
        }

        return await Result.SuccessAsync("Permission Updated");
    }

    public async Task<IResult> ResetPassword(ResetPasswordRequest request)
    {
        var userInDb = await _context.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Id == request.UserId);
        var hashedPassword = SecurePasswordHasher.Hash(request.NewPassword);
        userInDb.IsForceReset = false;
        userInDb.PasswordHash = hashedPassword;
        await _context.SaveChangesAsync();
        return await Result.SuccessAsync("Password has been reset");
    }

    #endregion
}