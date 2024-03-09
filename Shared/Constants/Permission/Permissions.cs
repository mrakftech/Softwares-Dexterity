using System.Collections.ObjectModel;
using System.Reflection;

namespace Shared.Constants.Permission;

public static class Permissions
{
    public const string Create = "Create";
    public const string Update = "Update";
    public const string Read = "Read";
    public const string Delete = "Delete";
    public const string Print = "Print";
    
    public const string UserAccounts = "User Accounts";
    
    

    public static List<string> AllClaims { get; set; } =
    [
        "Print",
        "Delete",
        "Update",
        "Read",
        "Create",
    ];

    public static ObservableCollection<string> Modules { get; set; } =
    [
        "User Accounts",
        "Permissions",
        "Service",
        "Mantainence"
    ];
    
    
}

