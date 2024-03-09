using System;
using System.ComponentModel;
using DexterityApp.Helpers;
using Shared.Responses.Patient;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AutoMapper;
using Services.Contracts.Repositroy;


namespace DexterityApp.ViewModels.User.Consultation
{
    public class ConsultationViewModel : Observable, INotifyPropertyChanged
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

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

        public ConsultationViewModel(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

            GetPatientsCommand = new RelayCommand(GetPatients);
        }

        private async void GetPatients()
        {
            Patients = await _unitOfWork.Patient.GetPatients();
        }
    }
}
