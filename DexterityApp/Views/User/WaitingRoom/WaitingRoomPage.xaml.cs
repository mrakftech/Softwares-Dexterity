using DexterityApp.ViewModels.User.Patient;
using DexterityApp.ViewModels.User.Patient.Dialogs;
using DexterityApp.ViewModels.User.WaitingRoom;
using DexterityApp.Views.User.PatientManagement.Dialogs;
using Features.Contracts.Repositroy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Services.Contracts.Repositroy;

namespace DexterityApp.Views.User.WaitingRoom
{
    /// <summary>
    /// Interaction logic for WaitingRoom.xaml
    /// </summary>
    public partial class WaitingRoomPage : Page
    {
        private readonly IUnitOfWork _unitOfWork;
        private Guid _id;

        public WaitingRoomPage(WaitingRoomViewModel vm, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            DataContext = vm;
        }

        private void OpenWaitingRoom_OnClick(object sender, RoutedEventArgs e)
        {
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }
    }
}