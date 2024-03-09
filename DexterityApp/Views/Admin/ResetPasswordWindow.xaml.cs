using System.Linq;
using System.Windows;
using DexterityApp.Helpers;
using DexterityApp.ViewModels.Admin;
using Features.Contracts.Repositroy;
using Services.Contracts.Repositroy;
using Shared.Requests.UserAccounts;
using Shared.State;

namespace DexterityApp.Views.Admin;

public partial class ResetPasswordWindow : Window
{
    private readonly IUnitOfWork _unitOfWork;

    public ResetPasswordWindow(ResetPasswordViewModel viewModel, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        InitializeComponent();
        DataContext = viewModel;
    }

    private async void ResetPassword()
    {
        if (!NewPasswordTxt.Text.Equals(ConfirmPasswordTxt.Text))
        {
            MessageBoxHelper.ShowFailMessage("Password is not matched");
        }

        var request = new ResetPasswordRequest()
        {
            UserId = ApplicationState.CurrentUser.UserId,
            NewPassword = NewPasswordTxt.Text
        };

        var result = await _unitOfWork.User.ResetPassword(request);
        if (result.Succeeded)
        {
            MessageBoxHelper.ShowSuccessMessage(result.Messages.First());
            Close();
        }
        else
        {
            MessageBoxHelper.ShowFailMessage(result.Messages.First());
        }
    }

    private void RestBtn_OnClick(object sender, RoutedEventArgs e)
    {
        ResetPassword();
    }
}