using System;
using System.Windows;
using DevExpress.Xpf.Grid;
using DexterityApp.ViewModels.User.Patient.Dialogs;
using DexterityApp.Views.User.PatientManagement.Accounts;
using DexterityApp.Views.User.PatientManagement.Family;
using DexterityApp.Views.User.PatientManagement.Options;
using Shared.Dtos.Patient;

namespace DexterityApp.Views.User.PatientManagement.Dialogs;

public partial class OpenPatientWindow : Window
{
    public PatientRequest Patient { get; set; }
    public Guid Id { get; set; }

    public OpenPatientWindow(OpenPatientViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void CloseWindow_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void View_CanSelectRow(object sender, CanSelectRowEventArgs e)
    {
        var id = (Guid) AccountsGridControl.GetFocusedRowCellValue("Id");
        if (id != Guid.Empty)
        {
            DeleteAlertBtn.Visibility = Visibility.Visible;
            ResolvedAlertBtn.Visibility = Visibility.Visible;
        }
    }

    private void NewFamilyButton_OnClick(object sender, RoutedEventArgs e)
    {
        var newFamilyWindow = new NewFamilyWindow();
        newFamilyWindow.ShowDialog();
    }

    private void RegisterFamily_OnClick(object sender, RoutedEventArgs e)
    {
        var registerFamily = new RegisterMemberWindow();
        registerFamily.ShowDialog();
    }

    private void RenameFamilyBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var renameFamily = new RenameFamilyWindow();
        renameFamily.ShowDialog();
    }

    private void RemoveFamilyBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var removeFamily = new RemoveFamilyWindow();
        removeFamily.ShowDialog();
    }

    private void TransferBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var tranferWindow = new TransferPatientWindow();
        tranferWindow.ShowDialog();
    }

    private void ChargeBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var chargeWindow = new ChargeWindow();
        chargeWindow.ShowDialog();
    }

    private void PaymentBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var paymentWindow = new PaymentWindow();
        paymentWindow.ShowDialog();
    }

    private void StrikeOff_OnClick(object sender, RoutedEventArgs e)
    {
        var strikeOffWindow = new StrikeOffWindow();
        strikeOffWindow.ShowDialog();
    }

    private void PrintStatement_OnClick(object sender, RoutedEventArgs e)
    {
        var printStatement = new PrintStatement();
        printStatement.ShowDialog();
    }

    private void PatientExport_OnClick(object sender, RoutedEventArgs e)
    {
        var patientPdfExporter = new PatientPdfExporter();
        patientPdfExporter.ShowDialog();
    }

    private void MergeBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var recordMergeWindow = new PatientRecordMergeWindow();
        recordMergeWindow.ShowDialog();
    }

    private void HospitalViewerBtn_OnClick(object sender, RoutedEventArgs e)
    {
        var recordMergeWindow = new PatientHospitalViewerWindow();
        recordMergeWindow.ShowDialog();
    }
}