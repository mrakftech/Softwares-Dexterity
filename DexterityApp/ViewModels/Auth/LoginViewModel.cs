using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DexterityApp.Contracts.Services;
using DexterityApp.Contracts.ViewModels;
using DexterityApp.Contracts.Views;
using DexterityApp.Helpers;
using DexterityApp.ViewModels.Common;
using Features.Contracts.Repositroy;
using Services.Contracts.Repositroy;
using Shared.Constants.Application;
using Shared.Constants.Role;
using Shared.Requests.Auth;
using Shared.Requests.UserAccounts;
using Shared.State;
using Syncfusion.Windows.Shared;

namespace DexterityApp.ViewModels.Auth;

public class LoginViewModel : Observable,IWindows
{
    
    public string Username { get; set; } = "user@dexterity";
    public string Password { get; set; } = ApplicationConstants.DefaultPassword;
    
    private DelegateCommand _hideCommand;
    private DelegateCommand HideCommand => _hideCommand ??= new DelegateCommand(HideWindow);

    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceProvider _serviceProvider;
    private IShellWindow _shellWindow;
    private readonly INavigationService _navigationService;
    
    
    public ICommand LoginCommand { get; set; }
    public ICommand ExitAppCommand { get; set; }
 

    public LoginViewModel(IUnitOfWork unitOfWork, IServiceProvider serviceProvider,
        INavigationService navigationService)
    {
        _unitOfWork = unitOfWork;
        _serviceProvider = serviceProvider;
        _navigationService = navigationService;

        LoginCommand = new RelayCommand(LoginUser);
        ExitAppCommand = new RelayCommand(ExitApplication);
    }

    private void ExitApplication()
    {
        Application.Current.Shutdown();
    }

    private async void LoginUser()
    {
        var request = new LoginRequest()
        {
            Username = Username,
            Password = Password
        };
        var result = await _unitOfWork.User.LoginAsync(request);
        if (result.Succeeded)
        {
            HideCommand.Execute(null);
            if (App.Current.Windows.OfType<IShellWindow>().Count() == 0)
            {
                // Default activation that navigates to the apps default page
                  

                _shellWindow = _serviceProvider.GetService(typeof(IShellWindow)) as IShellWindow;
                _navigationService.Initialize(_shellWindow.GetNavigationFrame());
                _shellWindow.ShowWindow();
                _navigationService.NavigateTo(typeof(HomeViewModel).FullName);
                await Task.CompletedTask;
            }
        }
        else
        {
            MessageBoxHelper.ShowFailMessage(result.Messages.First());
        }
    }
    private void HideWindow(object obj)
    {
        Hide?.Invoke();
    }

    public Action Hide { get; set; }
}

