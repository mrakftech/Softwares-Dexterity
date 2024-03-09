namespace Shared.Requests.UserAccounts;

public class ResetPasswordRequest
{
    public Guid UserId { get; set; }
    public string NewPassword { get; set; }
}