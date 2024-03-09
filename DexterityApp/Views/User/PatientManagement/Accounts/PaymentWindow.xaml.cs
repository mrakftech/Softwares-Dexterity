using System.Windows;
using DevExpress.Xpf.Editors;
using DexterityApp.Helpers;

namespace DexterityApp.Views.User.PatientManagement.Accounts;

public partial class PaymentWindow : Window
{
    public PaymentWindow()
    {
        InitializeComponent();
        DataContext = new PaymentViewModel();
    }

}

public class PaymentViewModel : Observable
{
    public string Title { get; set; } = "Accounting - Payment";
}