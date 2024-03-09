using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace DexterityApp.Views.User.PatientManagement.Options;

public partial class PatientPdfExporter : Window
{
    public PatientPdfExporter()
    {
        InitializeComponent();
    }
    

    private void SaveFileBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var saveFileDialog = new SaveFileDialog();
        if(saveFileDialog.ShowDialog() == true)
            File.WriteAllText(saveFileDialog.FileName, ExportDir.Text);
    }
}