using DevExpress.Mvvm;
using DevExpress.Xpf.Printing;
using DevExpress.Xpf.Scheduling;
using System.Windows;
using System.Windows.Controls;

namespace DexterityApp.Helpers;

public static class MyPrintHelper {
    public static Page mainWindow { get; set; }

    public static void PrintScheduler(SchedulerControl scheduler) {
        var report = new XtraSchedulerReport1();
        var dateTimeRange = scheduler.VisibleIntervals[0];
        scheduler.SchedulerPrintAdapter.DateTimeRange = dateTimeRange;
        scheduler.SchedulerPrintAdapter.AssignToReport(report);
        PrintHelper.ShowPrintPreview(mainWindow, report);
    }
}