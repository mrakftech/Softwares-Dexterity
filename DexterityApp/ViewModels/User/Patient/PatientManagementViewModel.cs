using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using DexterityApp.Helpers;
using Features.Contracts.Repositroy;
using Services.Contracts.Repositroy;
using Shared.Responses.Patient;

namespace DexterityApp.ViewModels.User.Patient;

public class PatientManagementViewModel : Observable, INotifyPropertyChanged
{
    private readonly IUnitOfWork _unitOfWork;
    private ObservableCollection<PatientListResponse> _patients = [];
    public ICommand GetPatientsCommand { get; set; }

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

    public PatientManagementViewModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        GetPatientsCommand = new RelayCommand(GetPatients);
    }

    private async void GetPatients()
    {
        Patients = await _unitOfWork.Patient.GetPatients();
    }
}