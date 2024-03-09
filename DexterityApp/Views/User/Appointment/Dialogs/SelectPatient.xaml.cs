using System.Windows;
using DexterityApp.ViewModels.User.Appointment.Dialogs;
using Features.Respository;
using Microsoft.Extensions.DependencyInjection;
using Services.Contracts.Repositroy;

namespace DexterityApp.Views.User.Appointment.Dialogs;

public partial class SelectPatient : Window
{
    public SelectPatient()
    {
        InitializeComponent();
    }
}