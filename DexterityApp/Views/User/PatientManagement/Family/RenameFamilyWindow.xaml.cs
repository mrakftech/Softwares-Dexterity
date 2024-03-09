using System.Windows;
using DexterityApp.Helpers;

namespace DexterityApp.Views.User.PatientManagement.Family;

public partial class RenameFamilyWindow : Window
{
    public RenameFamilyWindow()
    {
        InitializeComponent();
    }

    private void Cancel_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void SaveBtn_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBoxHelper.ShowSuccessMessage("Renamed successfully.");
    }
}