using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Database;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.LayoutControl;
using DexterityApp.Helpers;
using DexterityApp.ViewModels.Admin;
using Features.Contracts.Repositroy;
using Services.Contracts.Repositroy;
using Shared.Constants.Permission;
using Shared.Requests.UserAccounts;

namespace DexterityApp.Views.Admin;

public partial class PermissionsPage : Page
{
    private readonly IUnitOfWork _unitOfWork;

    public PermissionsPage(PermissionsViewModel viewModel, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        InitializeComponent();
        DataContext = viewModel;
    }


    private async void LoadPermissions_OnClick(object sender, RoutedEventArgs e)
    {
        CheckboxControl.IsEnabled = true;
        var roleName = UserRoleTxt.Text;
        var roleId = await _unitOfWork.User.GetRoleId(roleName);
        var permissions = await _unitOfWork.User.GetPermissions(roleId, Modulues.Text);
        foreach (var item in permissions)
        {
            switch (item.ClaimName)
            {
                case Permissions.Create:
                    CreateCbx.IsChecked = item.Allowed;
                    CreateCbx.Uid = item.Id.ToString();
                    break;
                case Permissions.Read:
                    ReadCbx.IsChecked = item.Allowed;
                    ReadCbx.Uid = item.Id.ToString();
                    break;
                case Permissions.Update:
                    UpdateCbx.IsChecked = item.Allowed;
                    UpdateCbx.Uid = item.Id.ToString();
                    break;
                case Permissions.Delete:
                    DeleteCbx.IsChecked = item.Allowed;
                    DeleteCbx.Uid = item.Id.ToString();
                    break;
                case Permissions.Print:
                    PrintCbx.IsChecked = item.Allowed;
                    PrintCbx.Uid = item.Id.ToString();
                    break;
            }
        }
    }
  
    private void UserRoleTxt_OnSelectedIndexChanged(object sender, RoutedEventArgs e)
    {
        if (UserRoleTxt.SelectedIndex != -1)
        {
            Modulues.IsEnabled = true;
        }
    }

    private void Modulues_OnSelectedIndexChanged(object sender, RoutedEventArgs e)
    {
        if (Modulues.SelectedIndex != -1)
        {
            LoadPermissions.IsEnabled = true;
            SaveButton.IsEnabled = true;
        }
    }

    private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
    {
        var list = new List<UpdatePermissionRequest>()
        {
            new()
            {
                Id = new Guid(CreateCbx.Uid),
                Value = CreateCbx.IsChecked != null && CreateCbx.IsChecked.Value
            },
            new()
            {
                Id = new Guid(ReadCbx.Uid),
                Value = ReadCbx.IsChecked != null && ReadCbx.IsChecked.Value
            },
            new()
            {
                Id = new Guid(UpdateCbx.Uid),
                Value = UpdateCbx.IsChecked != null && UpdateCbx.IsChecked.Value
            },
            new()
            {
                Id = new Guid(DeleteCbx.Uid),
                Value = DeleteCbx.IsChecked != null && DeleteCbx.IsChecked.Value
            },
            new()
            {
                Id = new Guid(PrintCbx.Uid),
                Value = PrintCbx.IsChecked != null && PrintCbx.IsChecked.Value
            }
        };
        var res = await _unitOfWork.User.UpdatePermissions(list);
        if (res.Succeeded)
        {
            MessageBoxHelper.ShowSuccessMessage(res.Messages.First());
        }
        else
        {
            MessageBoxHelper.ShowFailMessage(res.Messages.First());

        }
    }
}