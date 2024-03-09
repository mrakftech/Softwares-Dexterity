using System.Windows;
using DevExpress.Xpf.Editors;
using DexterityApp.Helpers;

namespace DexterityApp.Views.User.PatientManagement.Accounts;

public partial class ChargeWindow : Window
{
    public ChargeWindow()
    {
        InitializeComponent();
        DataContext = new ChargeViewModel();
    }

    private void CloseBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void MakePaymentCheckbox_OnEditValueChanged(object sender, EditValueChangedEventArgs e)
    {
        if (MakePaymentCheckbox.IsChecked != null && (bool) MakePaymentCheckbox.IsChecked)
        {
            PaymentGroupBox.IsEnabled = true;
        }
        else
        {
            PaymentGroupBox.IsEnabled = false;
        }
    }
}

public class ChargeViewModel : Observable
{
    public string Title { get; set; } = "Accounting - Charge";
}