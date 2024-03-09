using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using Database;
using DexterityApp.Contracts.Services;
using DexterityApp.Contracts.Views;
using DexterityApp.Models;
using DexterityApp.Services;
using DexterityApp.ViewModels;
using DexterityApp.ViewModels.Admin;
using DexterityApp.ViewModels.Auth;
using DexterityApp.ViewModels.Common;
using DexterityApp.ViewModels.User;
using DexterityApp.ViewModels.User.Appointment;
using DexterityApp.ViewModels.User.Consultation;
using DexterityApp.ViewModels.User.Patient;
using DexterityApp.ViewModels.User.WaitingRoom;
using DexterityApp.Views;
using DexterityApp.Views.Admin;
using DexterityApp.Views.Auth;
using DexterityApp.Views.Common;
using DexterityApp.Views.User;
using DexterityApp.Views.User.Appointment;
using DexterityApp.Views.User.Consultation;
using DexterityApp.Views.User.PatientManagement;
using DexterityApp.Views.User.WaitingRoom;
using Domain.Entites.UserAccounts;
using Features.Contracts.Modules;
using Features.Contracts.Repositroy;
using Features.DbInitaiizer;
using Features.Respository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Services.Contracts.Repositroy;
using Services.Features.PatientManagement.Service;
using Services.Features.UserAccounts.Service;

namespace DexterityApp
{
    // For more inforation about application lifecyle events see https://docs.microsoft.com/dotnet/framework/wpf/app-development/application-management-overview

    // WPF UI elements use language en-US by default.
    // If you need to support other cultures make sure you add converters and review dates and numbers in your UI to ensure everything adapts correctly.
    // Tracking issue for improving this is https://github.com/dotnet/wpf/issues/1946
    public partial class App : Application
    {
        private IHost _host;

        public T GetService<T>()
            where T : class
            => _host.Services.GetService(typeof(T)) as T;

        public App()
        {
            // Add your Syncfusion license key for WPF platform with corresponding Syncfusion NuGet version referred in project. For more information about license key see https://help.syncfusion.com/common/essential-studio/licensing/license-key.
            // Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Add your license key here"); 
        }

        private async void OnStartup(object sender, StartupEventArgs e)
        {
            var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            // For more information about .NET generic host see  https://docs.microsoft.com/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-3.0
            _host = Host.CreateDefaultBuilder(e.Args)
                .UseSerilog((host, logger) =>
                {
                    logger.WriteTo.Console()
                        .MinimumLevel.Error();
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseSqlServer(hostContext.Configuration.GetConnectionString("AppConnection")))
                        .AddTransient<IDatabaseSeeder, DatabaseSeeder>();
                    ;
                })
                .ConfigureAppConfiguration(c => { c.SetBasePath(appLocation); })
                .ConfigureServices(ConfigureServices)
                .Build();

            using (var scope = _host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var seeder = services.GetRequiredService<IDatabaseSeeder>();
                seeder.Initialize();
            }

            await _host.StartAsync();
        }

        private void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            CreateCoreServices(services);
            CreateModelAndViewModelService(context, services);
            ConfigureRepositoryWrapper(services);
        }

        private async void OnExit(object sender, ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
            _host = null;
        }

        private static IServiceProvider CreateCoreServices(IServiceCollection services)
        {
            // App Host
            services.AddHostedService<ApplicationHostService>();

            // Core Services
            services.AddSingleton<IFileService, FileService>();

            // Services
            services.AddSingleton<IWindowManagerService, WindowManagerService>();
            services.AddSingleton<IApplicationInfoService, ApplicationInfoService>();
            services.AddSingleton<ISystemService, SystemService>();
            services.AddSingleton<IPersistAndRestoreService, PersistAndRestoreService>();
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();
            return services.BuildServiceProvider();
        }

        private IServiceProvider CreateModelAndViewModelService(HostBuilderContext context, IServiceCollection services)
        {
// Views and ViewModels


            services.AddTransient<IShellWindow, ShellWindow>();
            services.AddTransient<ShellViewModel>();


            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();

            services.AddTransient<IShellDialogWindow, ShellDialogWindow>();
            services.AddTransient<ShellDialogViewModel>();


            // Configuration
            services.Configure<AppConfig>(context.Configuration.GetSection(nameof(AppConfig)));

            services.AddTransient<HomeViewModel>();
            services.AddTransient<HomePage>();

            services.AddTransient<UserAccountViewModel>();
            services.AddTransient<UserAccountsPage>();

            services.AddTransient<IWindowHandle, LoginPage>();
            services.AddTransient<LoginViewModel>();

            services.AddTransient<PermissionsViewModel>();
            services.AddTransient<PermissionsPage>();

            services.AddTransient<PatientManagementViewModel>();
            services.AddTransient<PatientManagementPage>();

            services.AddTransient<AppointmentViewModel>();
            services.AddTransient<AppointmentPage>();
            services.AddTransient<WaitingRoomViewModel>();
            services.AddTransient<WaitingRoomPage>();

            services.AddTransient<ConsultationViewModel>();
            services.AddTransient<ConsultationPage>();
            return services.BuildServiceProvider();
        }


        public static void ConfigureRepositoryWrapper(IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // TODO WTS: Please log and handle the exception as appropriate to your scenario
            // For more info see https://docs.microsoft.com/dotnet/api/system.windows.application.dispatcherunhandledexception?view=netcore-3.0
        }
    }
}