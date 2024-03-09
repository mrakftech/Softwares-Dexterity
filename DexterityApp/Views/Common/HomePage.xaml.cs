using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using DexterityApp.Helpers;
using DexterityApp.ViewModels.Admin;
using DexterityApp.ViewModels.Common;
using DexterityApp.Views.Admin;
using Features.Contracts.Repositroy;
using Services.Contracts.Repositroy;
using Shared.Constants.Role;
using Shared.State;

namespace DexterityApp.Views.Common
{
    public partial class HomePage : Page
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomePage(HomeViewModel viewModel, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeComponent();
            DataContext = viewModel;
        }

        private void HomePage_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (ApplicationState.CurrentUser.IsForceReset &&
                ApplicationState.CurrentUser.RoleName != RoleConstants.AdministratorRole)
            {
                var resetWindow = new ResetPasswordWindow(new ResetPasswordViewModel(), _unitOfWork);
                resetWindow.Show();
            }
        }
    }
}