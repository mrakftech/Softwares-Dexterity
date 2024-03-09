using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using DexterityApp.Contracts.Services;
using DexterityApp.Helpers;
using DexterityApp.ViewModels.Admin;
using DexterityApp.ViewModels.Common;
using DexterityApp.ViewModels.User;
using DexterityApp.ViewModels.User.Appointment;
using DexterityApp.ViewModels.User.Consultation;
using DexterityApp.ViewModels.User.Patient;
using DexterityApp.ViewModels.User.WaitingRoom;
using Shared.Constants.Application;
using Shared.Constants.Role;
using Shared.State;

namespace DexterityApp.ViewModels
{
    public class ShellViewModel : Observable
    {
        private ICommand _optionsMenuItemInvokedCommand;
        private ICommand _logOutCommand;

        private Brush _secondaryColor = new SolidColorBrush(Colors.Firebrick);

        private readonly INavigationService _navigationService;
        private object _selectedMenuItem;
        private ICommand _menuItemInvokedCommand;
        private ICommand _loadedCommand;
        private ICommand _unloadedCommand;


        public ShellViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SetttingsIconColor = (new SolidColorBrush(Colors.Firebrick));
            LoadMenuItems();
        }

        public object SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                if (value as NavigationPaneItem == null)
                {
                    Set(ref _selectedMenuItem, ((FrameworkElement) value).DataContext, "SelectedMenuItem");
                }
                else
                {
                    Set(ref _selectedMenuItem, value, "SelectedMenuItem");
                }

                //NavigateTo((_selectedMenuItem as NavigationPaneItem).TargetType);
                if (_selectedMenuItem is NavigationPaneItem navigationPaneItem && navigationPaneItem.TargetType != null)
                {
                    NavigateTo(navigationPaneItem.TargetType);
                }
            }
        }

        public void UpdateFillColor(SolidColorBrush fillColor)
        {
            foreach (var item in MenuItems)
            {
                item.Path.Fill = fillColor;
            }

            SetttingsIconColor = fillColor;
        }

        private SolidColorBrush setttingsIconColor;

        public SolidColorBrush SetttingsIconColor
        {
            get { return setttingsIconColor; }
            set
            {
                setttingsIconColor = value;
                OnPropertyChanged(nameof(SetttingsIconColor));
            }
        }

        public ObservableCollection<NavigationPaneItem> MenuItems { get; set; }


        public ICommand OptionsMenuItemInvokedCommand =>
            _optionsMenuItemInvokedCommand ??= new RelayCommand(OnOptionsMenuItemInvoked);

        public ICommand LogoutCommand => _logOutCommand ??= new RelayCommand(Logout);

        private void Logout()
        {
            ApplicationState.CurrentUser = null;
            ApplicationState.IsLoggedIn = false;
            System.Windows.Forms.Application.Restart();
            System.Windows.Application.Current.Shutdown();
        }


        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(OnLoaded));

        public ICommand UnloadedCommand => _unloadedCommand ?? (_unloadedCommand = new RelayCommand(OnUnloaded));


        private void OnLoaded()
        {
            _navigationService.Navigated += OnNavigated;
        }

        private void LoadMenuItems()
        {
            ObservableCollection<NavigationPaneItem> items;
            if (ApplicationState.CurrentUser.RoleName == RoleConstants.AdministratorRole)
            {
                items =
                [
                    new()
                    {
                        Label = MenuConstants.UserAccounts,
                        Path = new Path()
                        {
                            Width = 15,
                            Height = 15,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Data = Geometry.Parse(Icons.UserAccounts),
                            Fill = _secondaryColor,
                            Stretch = Stretch.Fill,
                        },
                        TargetType = typeof(UserAccountViewModel)
                    },

                    new NavigationPaneItem
                    {
                        Label = MenuConstants.Permissions,
                        Path = new Path()
                        {
                            Width = 15,
                            Height = 15,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Data = Geometry.Parse(Icons.Permissions),
                            Fill = _secondaryColor,
                            Stretch = Stretch.Fill,
                        },
                        TargetType = typeof(PermissionsViewModel)
                    },

                    new NavigationPaneItem
                    {
                        Label = MenuConstants.Services,
                        Path = new Path()
                        {
                            Width = 15,
                            Height = 15,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Data = Geometry.Parse(Icons.Services),
                            Fill = _secondaryColor,
                            Stretch = Stretch.Fill,
                        },
                        TargetType = typeof(UserAccountViewModel)
                    },

                    new NavigationPaneItem
                    {
                        Label = MenuConstants.Maintenance,
                        Path = new Path()
                        {
                            Width = 15,
                            Height = 15,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Data = Geometry.Parse(Icons.Maintenance),
                            Fill = _secondaryColor,
                            Stretch = Stretch.Fill,
                        },
                        TargetType = typeof(UserAccountViewModel)
                    }
                ];
                MenuItems = items;
            }
            else
            {
                items =
                [
                    new NavigationPaneItem
                    {
                        Label = MenuConstants.Appointments,
                        Path = new Path()
                        {
                            Width = 15,
                            Height = 15,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Data = Geometry.Parse(Icons.Appointments),
                            Fill = _secondaryColor,
                            Stretch = Stretch.Fill,
                        },
                        TargetType = typeof(AppointmentViewModel)
                    },
                    new NavigationPaneItem
                    {
                        Label = MenuConstants.Waitingroom,
                        Path = new Path()
                        {
                            Width = 15,
                            Height = 15,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Data = Geometry.Parse(Icons.WaitingRoom),
                            Fill = _secondaryColor,
                            Stretch = Stretch.Fill,
                        },
                        TargetType = typeof(WaitingRoomViewModel)
                    },
                    new NavigationPaneItem
                    {
                        Label = MenuConstants.PatientManagement,
                        Path = new Path()
                        {
                            Width = 15,
                            Height = 15,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Data = Geometry.Parse(Icons.PatientManagement),
                            Fill = _secondaryColor,
                            Stretch = Stretch.Fill,
                        },
                        TargetType = typeof(PatientManagementViewModel)
                    },
                    new NavigationPaneItem
                    {
                        Label = MenuConstants.Consultation,
                        Path = new Path()
                        {
                            Width = 15,
                            Height = 15,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Data = Geometry.Parse(Icons.Consultation),
                            Fill = _secondaryColor,
                            Stretch = Stretch.Fill,
                        },
                        TargetType = typeof(ConsultationViewModel)
                    },
                    new NavigationPaneItem
                    {
                        Label = MenuConstants.Reports,
                        Path = new Path()
                        {
                            Width = 15,
                            Height = 15,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Data = Geometry.Parse(Icons.Reports),
                            Fill = _secondaryColor,
                            Stretch = Stretch.Fill,
                        },
                        TargetType = typeof(UserAccountViewModel)
                    },
                    new NavigationPaneItem
                    {
                        Label = MenuConstants.Communication,
                        Path = new Path()
                        {
                            Width = 15,
                            Height = 15,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Data = Geometry.Parse(Icons.Communication),
                            Fill = _secondaryColor,
                            Stretch = Stretch.Fill,
                        },
                        TargetType = typeof(UserAccountViewModel)
                    }
                ];
                MenuItems = items;
            }
        }

        private void OnUnloaded()
        {
            _navigationService.Navigated -= OnNavigated;
        }

        private bool CanGoBack()
            => _navigationService.CanGoBack;

        private void OnGoBack()
            => _navigationService.GoBack();

        private void NavigateTo(Type targetViewModel)
        {
            if (targetViewModel != null)
            {
                _navigationService.NavigateTo(targetViewModel.FullName);
            }
        }

        private void OnNavigated(object sender, string viewModelName)
        {
            var item = MenuItems
                .OfType<NavigationPaneItem>()
                .FirstOrDefault(i => viewModelName == i.TargetType?.FullName);
            if (item != null)
            {
                SelectedMenuItem = item;
            }
        }

        private void OnOptionsMenuItemInvoked()
            => NavigateTo(typeof(SettingsViewModel));
    }

    public class NavigationPaneItem
    {
        public string Label { get; set; }
        public Path Path { get; set; }
        public Type TargetType { get; set; }
    }
}