using System.Windows;
using DexterityApp.Helpers;

namespace DexterityApp.Views.User.PatientManagement.Accounts;

public partial class StrikeOffWindow : Window
{
    public StrikeOffWindow()
    {
        InitializeComponent();
        DataContext = new StrikeOffViewModel();
    }
}

public class StrikeOffViewModel : Observable
{
    public string Title { get; set; } = "Accounting - Strike-Off";
}