using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using DevExpress.Xpf.Bars;
using DexterityApp.ViewModels.Admin;
using Features.Contracts.Repositroy;
using Services.Contracts.Repositroy;
using Shared.Helper;
using Shared.Responses.UserAccounts;
using MessageBox = System.Windows.Forms.MessageBox;

namespace DexterityApp.Views.Admin;

public partial class UserAccountsPage : Page
{
    private readonly IUnitOfWork _unitOfWork;

    public UserAccountsPage(UserAccountViewModel viewModel, IUnitOfWork unitOfWork)
    {
        InitializeComponent();
        _unitOfWork = unitOfWork;
        DataContext = viewModel;
    }

    private void DXTabControl_SelectionChanged(object sender, DevExpress.Xpf.Core.TabControlSelectionChangedEventArgs e)
    {
    }


    private void Clear(object sender, RoutedEventArgs e)
    {
        IdTxt.Text = Guid.Empty.ToString();
        FirstNameTxt.Clear();
        LastNameTxt.Clear();
        EmailTxt.Clear();
        PhoneTxt.Clear();
        UserTypeTxt.Clear();
        UserRoleTxt.Clear();
        McnTxt.Clear();
        UsernameTxt.Clear();
        PasswordTxt.Clear();
        ResetPasswordTxt.Clear();
        ClearButton.Content = "Clear";
        FormTitle.Text = "New User";
        UserSavingTab.Header = "Register New User";
    }


    private async void EditItem(object sender, ItemClickEventArgs e)
    {
        var id = (Guid) UserGridControl.GetFocusedRowCellValue("Id");
        var user = await _unitOfWork.User.GetUser(id);
        EditUserLoad(user);
        UserAccountTabControl.SelectedIndex = 0;
    }

    private void EditUserLoad(UserResponse user)
    {
        ClearButton.Content = "New User";
        UserSavingTab.Header = "Edit User";
        FormTitle.Text = $"Edit User - {user.FullName}";
        IdTxt.Text = user.Id.ToString();
        FirstNameTxt.Text = user.FirstName;
        LastNameTxt.Text = user.LastName;
        EmailTxt.Text = user.Email;
        PhoneTxt.Text = user.Phone;
        UserTypeTxt.Text = user.UserType;
        UserRoleTxt.Text = user.Role.Name;
        McnTxt.Text = user.Mcn;
        UsernameTxt.Text = user.Username;
        IsActiveCheckBox.IsChecked = user.IsActive;
        //IsUpdatePasswordCheckBox.IsChecked = user.IsUpdatePassword;
        IsForceResetCheckBox.IsChecked = user.IsForceReset;
        PasswordTxt.Text = user.PasswordHash;
        ResetPasswordTxt.Text = Method.GetPasswordResetIn(user.ResetPasswordAt);
    }

    private async void Delete_OnItemClick(object sender, ItemClickEventArgs e)
    {
        var dialogResult = MessageBox.Show(@"Do you want to delete?", @"Confirmation", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        if (dialogResult == DialogResult.Yes)
        {
            var id = (Guid) UserGridControl.GetFocusedRowCellValue("Id");
            var result = await _unitOfWork.User.DeleteUser(id);
            if (result.Succeeded)
            {
                UserView.DeleteRow(UserView.FocusedRowHandle);
                MessageBox.Show(result.Messages.First(), @"Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(result.Messages.First(), @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }

    private void DeleteUserButton_OnClick(object sender, RoutedEventArgs e)
    {
        Delete_OnItemClick(null, null);
    }

    private void EditUserButton_OnClick(object sender, RoutedEventArgs e)
    {
        EditItem(null, null);
    }
}