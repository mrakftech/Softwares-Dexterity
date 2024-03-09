using DexterityApp.Helpers;
using Features.Contracts.Repositroy;
using Shared.Responses.Patient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DevExpress.Mvvm;
using System.Windows.Input;
using DevExpress.DirectX.Common.Direct2D;
using Services.Contracts.Repositroy;


namespace DexterityApp.ViewModels.User.WaitingRoom
{
    public class WaitingRoomViewModel : Observable, INotifyPropertyChanged
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

        public WaitingRoomViewModel(IUnitOfWork unitOfWork, IMapper mapper)
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
