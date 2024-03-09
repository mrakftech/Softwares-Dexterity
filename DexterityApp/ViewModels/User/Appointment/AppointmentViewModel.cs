using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DevExpress.Mvvm;
using DevExpress.Xpf.Scheduling;
using DexterityApp.Helpers;
using DexterityApp.Models;
using Shared.Constants.Module;

namespace DexterityApp.ViewModels.User.Appointment;

public class AppointmentViewModel : Observable
{
    public virtual ObservableCollection<Doctor> Doctors { get; set; }
    public virtual ObservableCollection<MedicalAppointment> Appointments { get; set; }
    public List<string> Data { get; set; } = PatientConstants.PatientStatus;
    public ICommand PrintSchedulerCommand { get; set; }

    public AppointmentViewModel()
    {
        CreateDoctors();
        CreateMedicalAppointments();
        PrintSchedulerCommand = new RelayCommand<SchedulerControl>(PrintScheduler);
    }

    private void CreateDoctors()
    {
        Doctors = new ObservableCollection<Doctor>();
        Doctors.Add(Doctor.Create(Id: 1, Name: "Stomatologist"));
        Doctors.Add(Doctor.Create(Id: 2, Name: "Ophthalmologist"));
        Doctors.Add(Doctor.Create(Id: 3, Name: "Surgeon"));
    }

    private void CreateMedicalAppointments()
    {
        Appointments = new ObservableCollection<MedicalAppointment>();
        Appointments.Add(MedicalAppointment.Create(
            startTime: DateTime.Now.Date.AddHours(10), endTime: DateTime.Now.Date.AddHours(11),
            doctorId: 1, notes: "", location: "101", categoryId: 1, patientName: "Dave Muriel",
            insuranceNumber: "396-36-XXXX", firstVisit: true));
    }
    
    #region #PrintScheduler
    public void PrintScheduler(SchedulerControl scheduler) {
        MyPrintHelper.PrintScheduler(scheduler);
    }
    #endregion #PrintScheduler
}