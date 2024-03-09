using AutoMapper;
using Domain.Entites.UserAccounts;
using Shared.Requests.UserAccounts;
using Shared.Responses.UserAccounts;

namespace Services.Features.UserAccounts.Mappings;

public class UserMappingProfile :Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, CreateUserRequest>().ReverseMap();
        CreateMap<User, UserResponse>().ReverseMap();
        CreateMap<Role, RoleResponse>().ReverseMap();
        CreateMap<PermissionClaim, PermissionResponse>().ReverseMap();
    }
}