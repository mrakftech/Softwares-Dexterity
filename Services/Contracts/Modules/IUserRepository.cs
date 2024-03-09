using System.Collections.ObjectModel;
using Domain.Entites.UserAccounts;
using Features.Contracts.Repositroy;
using Shared.Requests.Auth;
using Shared.Requests.UserAccounts;
using Shared.Responses.UserAccounts;
using Shared.Wrapper;

namespace Features.Contracts.Modules;

public interface IUserRepository: IRepositoryBase<User>
{
    Task<Result<LoginResponse>> LoginAsync(LoginRequest request);

    Task<ObservableCollection<UserResponse>> GetUsers();
    Task<UserResponse> GetUser(Guid id);
    Task<IResult> SaveUser(CreateUserRequest request);
    Task<IResult> DeleteUser(Guid id);

    Task<RoleResponse> GetUserRole(Guid roleId);
    Task<Guid> GetRoleId(string name);
    void Logout();

    #region Permissions

    Task<ObservableCollection<PermissionResponse>> GetPermissions(Guid roleId, string module = null);
    Task<IResult> UpdatePermissions(List<UpdatePermissionRequest> request);
    Task<IResult> ResetPassword(ResetPasswordRequest request);

    #endregion
}