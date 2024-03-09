using System;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using DevExpress.Xpf.Grid;
using DexterityApp.Helpers;
using DexterityApp.ViewModels.User.Patient;
using DexterityApp.ViewModels.User.Patient.Dialogs;
using DexterityApp.Views.User.PatientManagement.Dialogs;
using Features.Contracts.Repositroy;
using Services.Contracts.Repositroy;
using MessageBox = System.Windows.Forms.MessageBox;

namespace DexterityApp.Views.User.PatientManagement;

public partial class PatientManagementPage : Page
{
    private readonly IUnitOfWork _unitOfWork;
    private Guid _id;

    public PatientManagementPage(PatientManagementViewModel vm, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        InitializeComponent();
        DataContext = vm;
    }

    private void EditPatient_Click(object sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private async void DeletePatient_OnClick(object sender, RoutedEventArgs e)
    {
        var dialogResult = MessageBox.Show(@"Do you want to delete?", @"Confirmation", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
        if (dialogResult == DialogResult.Yes)
        {
            var id = (Guid) PatientGridControl.GetFocusedRowCellValue("Id");
            var result = await _unitOfWork.Patient.DeletePatient(id);
            if (result.Succeeded)
            {
                PatientView.DeleteRow(PatientView.FocusedRowHandle);
                MessageBoxHelper.ShowSuccessMessage(result.Messages.First());
            }
            else
            {
                MessageBoxHelper.ShowFailMessage(result.Messages.First());
            }
        }
    }

    private void AddNewPatient_Click(object sender, RoutedEventArgs e)
    {
        var newPatientWindow = new AddNewPatientWindow(new AddNewPatientViewModel(_unitOfWork));
        newPatientWindow.ShowDialog();
    }

    private void OpenPatient_OnClick(object sender, RoutedEventArgs e)
    {
        var patientDetailWindow = new OpenPatientWindow(new OpenPatientViewModel(_unitOfWork));
        patientDetailWindow.Id = _id;
        patientDetailWindow.ShowDialog();
    }

    private void PatientTabControl_OnItemsChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
    }

    private void View_CanSelectRow(object sender, CanSelectRowEventArgs e)
    {
        _id = (Guid) PatientGridControl.GetFocusedRowCellValue("Id");
        if (_id != Guid.Empty)
        {
            OpenPatientBtn.IsEnabled = true;
            PatientSummaryBtn.IsEnabled = true;
        }
    }

    private void SummaryPatient_OnClick(object sender, RoutedEventArgs e)
    {
        var summaryWindow = new PatientSummaryWindow(new PatientSummaryViewModel(_unitOfWork))
        {
            Id = _id
        };
        summaryWindow.ShowDialog();
    }
}