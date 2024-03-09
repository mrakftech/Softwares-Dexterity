using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DexterityApp.Contracts.Services;
using DexterityApp.Contracts.Views;
using DexterityApp.Models;
using DexterityApp.ViewModels.Common;
using Microsoft.Extensions.Hosting;

namespace DexterityApp.Services
{
    public class ApplicationHostService(
        IServiceProvider serviceProvider,
        INavigationService navigationService,
        IThemeSelectorService themeSelectorService,
        IPersistAndRestoreService persistAndRestoreService)
        : IHostedService
    {
        private IWindowHandle _windowHandle;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Initialize services that you need before app activation
            await InitializeAsync();

            await HandleActivationAsync();

            // Tasks after activation
            await StartupAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            persistAndRestoreService.PersistData();
            await Task.CompletedTask;
        }

        private async Task InitializeAsync()
        {
            persistAndRestoreService.RestoreData();
            AppTheme theme = themeSelectorService.GetCurrentTheme() != null
                ? themeSelectorService.GetCurrentTheme()
                : AppTheme.MaterialLightBlue;
            themeSelectorService.SetTheme(theme);
            await Task.CompletedTask;
        }

        private async Task StartupAsync()
        {
            await Task.CompletedTask;
        }

        private async Task HandleActivationAsync()
        {
            // if (App.Current.Windows.OfType<IShellWindow>().Count() == 0)
            // {
            //     // Default activation that navigates to the apps default page
            //     _shellWindow = serviceProvider.GetService(typeof(IShellWindow)) as IShellWindow;
            //     navigationService.Initialize(_shellWindow.GetNavigationFrame());
            //     _shellWindow.ShowWindow();
            //     navigationService.NavigateTo(typeof(HomeViewModel).FullName);
            //     await Task.CompletedTask;
            // }

            if (App.Current.Windows.OfType<IWindowHandle>().Count() == 0)
            {
                // Default activation that navigates to the apps default page
                _windowHandle = serviceProvider.GetService(typeof(IWindowHandle)) as IWindowHandle;
                _windowHandle.ShowWindow();
                await Task.CompletedTask;
            }
        }
    }
}