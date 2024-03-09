namespace Shared.Constants.Role;

public static class RoleConstants
{
    public const string AdministratorRole = "Admin";
    public const string UserRole = "User";
    public const string GroupRole = "Group";
  
    public static List<string> Roles { get; set; } =
    [
        AdministratorRole,
        UserRole
    ];
    
 

}