using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DevExpress.Mvvm;
using DexterityApp.Contracts.Views;
using DexterityApp.Helpers;
using Features.Contracts.Repositroy;
using Services.Contracts.Repositroy;
using Shared.Constants.Module;
using Shared.Dtos.Patient;

namespace DexterityApp.ViewModels.User.Patient.Dialogs;

public class AddNewPatientViewModel : Observable
{
    private readonly IUnitOfWork _unitOfWork;
    public PatientRequest Patient { get; set; } = new();
    public List<string> Gender { get; set; } = PatientConstants.Gender;
    public List<string> PatientTypes { get; set; } = PatientConstants.PatientTypes;

    public ICommand SavePatientCommand { get; set; }
    public ICommand CloseWindowCommand { get; set; }

    public AddNewPatientViewModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        SavePatientCommand = new RelayCommand<ICloseable>(SavePatient);
        CloseWindowCommand = new RelayCommand<ICloseable>(CloseWindow);
    }

    public void CloseWindow(ICloseable window)
    {
        if (window != null)
        {
            window.Close();
        }
    }

    private async void SavePatient(ICloseable window)
    {
        if (!IDataErrorInfoHelper.HasErrors(Patient))
        {
            var result = await _unitOfWork.Patient.CreatePatient(Patient, default);
            if (result.Succeeded)
            {
                MessageBoxHelper.ShowSuccessMessage(result.Messages.First());
                CloseWindowCommand.Execute(window);
            }
            else
            {
                MessageBoxHelper.ShowFailMessage(result.Messages.First());
            }
        }
        else
        {
            MessageBoxHelper.ShowFailMessage(Patient.Error);
        }
    }
}