using System.Windows;
using DexterityApp.Contracts.Views;
using DexterityApp.ViewModels.User.Patient;
using DexterityApp.ViewModels.User.Patient.Dialogs;

namespace DexterityApp.Views.User.PatientManagement;

public partial class AddNewPatientWindow : Window, ICloseable
{
    public AddNewPatientWindow(AddNewPatientViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void CloseWindow_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

}