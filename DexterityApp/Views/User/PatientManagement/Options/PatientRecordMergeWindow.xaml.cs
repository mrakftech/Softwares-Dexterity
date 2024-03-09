using System.Windows;

namespace DexterityApp.Views.User.PatientManagement.Options;

public partial class PatientRecordMergeWindow : Window
{
    public PatientRecordMergeWindow()
    {
        InitializeComponent();
    }

    private void CloseWindow_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}