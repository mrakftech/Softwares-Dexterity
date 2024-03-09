using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using DexterityApp.Helpers;
using Shared.Constants.Permission;
using Shared.Constants.Role;

namespace DexterityApp.ViewModels.Admin;

public class PermissionsViewModel : Observable, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private ObservableCollection<string> _modules = [];

    protected void NotifyPropertyChanged(String info)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }
    public List<string> Roles { get; set; } = RoleConstants.Roles;
    public ObservableCollection<string> Modules
    {
        get { return _modules; }
        set
        {
            if (value != _modules)
            {
                _modules = value;
                NotifyPropertyChanged("Modules");
            }
        }
    }

    public PermissionsViewModel()
    {
        GetPermissions();
    }

    private void GetPermissions()
    {
        Modules = Permissions.Modules;
    }
}