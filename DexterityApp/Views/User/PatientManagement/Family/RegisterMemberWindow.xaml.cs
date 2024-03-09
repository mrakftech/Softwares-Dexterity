using System.Windows;

namespace DexterityApp.Views.User.PatientManagement.Family;

public partial class RegisterMemberWindow : Window
{
    public RegisterMemberWindow()
    {
        InitializeComponent();
    }

    private void Cancel_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}