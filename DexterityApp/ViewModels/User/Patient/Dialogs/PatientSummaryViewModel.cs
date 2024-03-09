using System;
using System.ComponentModel;
using System.Windows.Input;
using DexterityApp.Helpers;
using Features.Contracts.Repositroy;
using Services.Contracts.Repositroy;
using Shared.Responses.Patient;

namespace DexterityApp.ViewModels.User.Patient.Dialogs;

public class PatientSummaryViewModel : Observable, INotifyPropertyChanged
{
    private readonly IUnitOfWork _unitOfWork;


    private PatientResponse _patient { get; set; } = new();

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

    public ICommand GetPatientCommand { get; set; }

    public PatientSummaryViewModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        GetPatientCommand = new RelayCommand<Guid>(GetPatient);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged(String info)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
    }

    private async void GetPatient(Guid id)
    {
        var patient = await _unitOfWork.Patient.GetPatient(id);
        var dateWithAge = GetAge(patient.DateOfBirth);
        patient.Dob = dateWithAge;

        Patient = patient;
    }

    private string GetAge(DateOnly dob)
    {
        var currentDate = DateOnly.FromDateTime(DateTime.Today);
        var age = currentDate.Year - dob.Year;

        if (currentDate < dob.AddYears(age))
        {
            age--;
        }

        return $"{dob:d} (Age {age} yrs)";
    }
}