using System.Windows;

namespace DexterityApp.Views.User.PatientManagement.Dialogs;

public partial class AddOrEditHospital : Window
{
    public AddOrEditHospital()
    {
        InitializeComponent();
    }

    private void Cancel_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}