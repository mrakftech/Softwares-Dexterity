using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using DexterityApp.Helpers;
using Features.Contracts.Repositroy;
using Services.Contracts.Repositroy;
using Shared.Responses.Patient;

namespace DexterityApp.ViewModels.User.Appointment.Dialogs;

public class SelectPatientViewModel : Observable, INotifyPropertyChanged
{
    private readonly IUnitOfWork _unitOfWork;
    public ICommand GetPatientsCommand { get; set; }

    private ObservableCollection<PatientListResponse> _patients = [];

    public SelectPatientViewModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        GetPatientsCommand = new RelayCommand(GetPatients);
    }

    public ObservableCollection<PatientListResponse> Patients
    {
        get { return _patients; }
        set
        {
            if (value != _patients)
            {
                _patients = value;
                NotifyPropertyChanged("Patients");
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

    private async void GetPatients()
    {
        Patients = await _unitOfWork.Patient.GetPatients();
    }
}