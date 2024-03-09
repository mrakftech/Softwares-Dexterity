using DexterityApp.Helpers;

namespace DexterityApp.ViewModels.Admin;

public class ResetPasswordViewModel : Observable
{
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
}