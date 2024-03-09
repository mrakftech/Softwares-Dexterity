using System;
using System.Windows;
using DexterityApp.ViewModels.User.Patient.Dialogs;

namespace DexterityApp.Views.User.PatientManagement.Dialogs;

public partial class PatientSummaryWindow : Window
{
    public Guid Id { get; set; }
    public PatientSummaryWindow(PatientSummaryViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }


  
}