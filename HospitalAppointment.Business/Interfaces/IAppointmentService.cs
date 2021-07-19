using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.Business.Interfaces
{
    public interface IAppointmentService:IGenericService<Appointment>
    {
        List<DateTime> GetAppointmentsHourTimesByAppointmentDayAndDoctorId(DateTime day, int doctorId);
        List<Appointment> GetPatientRegistrarAppointmentsWithAllTables(int id);
        List<Appointment> GetPatientPastAppointmentsByPatientId(int id);
        List<Appointment> GetPatientFutureAppointmentsByPatientId(int id);
        List<Appointment> GetTodayAppointmentsByDoctorId(int id);
        void RemoveAppointmentByDateAndDoctorId(DateTime appointmentDateTime, int patientId);
        Appointment GetAppointmentByPatientIdAndDateTime(int patientId, DateTime appDateTime);
    }
}
