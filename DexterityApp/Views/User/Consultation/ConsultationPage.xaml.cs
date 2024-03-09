using DexterityApp.ViewModels.User.Consultation;
using DexterityApp.ViewModels.User.WaitingRoom;
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

namespace DexterityApp.Views.User.Consultation
{
    /// <summary>
    /// Interaction logic for Consultation.xaml
    /// </summary>
    public partial class ConsultationPage : Page
    {
        private readonly IUnitOfWork _unitOfWork;
        private Guid _id;
        public ConsultationPage(ConsultationViewModel vm, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            DataContext = vm;
        }        

    }
}
