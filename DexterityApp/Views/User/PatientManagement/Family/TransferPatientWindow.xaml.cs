using System.Windows;

namespace DexterityApp.Views.User.PatientManagement.Family;

public partial class TransferPatientWindow : Window
{
    public TransferPatientWindow()
    {
        InitializeComponent();
    }

    private void CancleBtn_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}