using System.Windows;

namespace DexterityApp.Views.User.PatientManagement.Options;

public partial class PatientHospitalViewerWindow : Window
{
    public PatientHospitalViewerWindow()
    {
        InitializeComponent();
    }

    private void CloseWindow_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}