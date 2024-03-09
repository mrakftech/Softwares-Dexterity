using System;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Scheduling;
using DevExpress.XtraScheduler;
using DexterityApp.Helpers;
using DexterityApp.ViewModels.User.Appointment;

namespace DexterityApp.Views.User.Appointment;

public partial class AppointmentPage : Page
{
    public AppointmentPage()
    {
        InitializeComponent();
        DataContext = new AppointmentViewModel();
        MyPrintHelper.mainWindow = this;
    }

    private void DayView_OnClick(object sender, RoutedEventArgs e)
    {
        // Switch the Scheduler to the Day View mode.
        ApptSchedulerControl.ActiveViewType =  (ViewType?) SchedulerViewType.Day;
        
        
    }

    private void WorkWeek_OnClick(object sender, RoutedEventArgs e)
    {
        // Switch the Scheduler to the Work Week View mode.
        ApptSchedulerControl.ActiveViewType =  (ViewType?) SchedulerViewType.WorkWeek;
    }

    private void TodayBtn_OnClick(object sender, RoutedEventArgs e)
    {
        ApptSchedulerControl.Commands.GoToTodayCommand.Execute(null);
    }

  
    

}