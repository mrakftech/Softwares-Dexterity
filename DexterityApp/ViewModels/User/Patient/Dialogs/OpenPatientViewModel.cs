using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using DexterityApp.Contracts.Views;
using DexterityApp.Helpers;
using Features.Contracts.Repositroy;
using Services.Contracts.Repositroy;
using Shared.Constants.Module;
using Shared.Responses.Patient;

namespace DexterityApp.ViewModels.User.Patient.Dialogs;

public class OpenPatientViewModel : Observable, INotifyPropertyChanged
{
    private readonly IUnitOfWork _unitOfWork;
    private PatientResponse _patient { get; set; } = new();
    public ICommand GetPatientCommand { get; set; }
    public ICommand CloseWindowCommand { get; set; }

    public List<string> Gender { get; set; } = PatientConstants.Gender;
    public List<string> PatientTypes { get; set; } = PatientConstants.PatientTypes;
    public List<string> PatientStatus { get; set; } = PatientConstants.PatientStatus;
    public List<string> Title { get; set; } = PatientConstants.Title;
    public PatientResponse Patient
    {
        get { return _patient; }
        set
        {
            if (value != _patient)
            {
                _patient = value;
                NotifyPropertyChanged("Patient");
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged(String info)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }

    public OpenPatientViewModel(IUnitOfWork patientService)
    {
        _unitOfWork = patientService;
        GetPatientCommand = new RelayCommand<Guid>(GetPatient);
        CloseWindowCommand = new RelayCommand<ICloseable>(CloseWindow);
    }
    private async void GetPatient(Guid id)
    {
        var patient = await _unitOfWork.Patient.GetPatient(id);

        Patient = patient;
    }
    
    public void CloseWindow(ICloseable window)
    {
        if (window != null)
        {
            window.Close();
        }
    }
}