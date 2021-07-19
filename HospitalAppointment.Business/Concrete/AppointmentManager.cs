using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.Business.Concrete
{
    public class AppointmentManager:GenericManager<Appointment>,IAppointmentService
    {
        private readonly IAppointmentDal _appointmentDal;
        public AppointmentManager(IGenericDal<Appointment> genericDal,IAppointmentDal appointmentDal) : base(genericDal)
        {
            _appointmentDal = appointmentDal;
        }

        public List<DateTime> GetAppointmentsHourTimesByAppointmentDayAndDoctorId(DateTime day, int doctorId)
        {
            return _appointmentDal.GetAppointmentsHourTimesByAppointmentDayAndDoctorId(day, doctorId);
        }

        public List<Appointment> GetPatientRegistrarAppointmentsWithAllTables(int id)
        {
            return _appointmentDal.GetPatientRegistrarAppointmentsWithAllTables(id);
        }

        public List<Appointment> GetPatientPastAppointmentsByPatientId(int id)
        {
            return _appointmentDal.GetPatientPastAppointmentsByPatientId(id);
        }

        public List<Appointment> GetPatientFutureAppointmentsByPatientId(int id)
        {
            return _appointmentDal.GetPatientFutureAppointmentsByPatientId(id);
        }

        public List<Appointment> GetTodayAppointmentsByDoctorId(int id)
        {
            return _appointmentDal.GetTodayAppointmentsByDoctorId(id);
        }

        public void RemoveAppointmentByDateAndDoctorId(DateTime appointmentDateTime, int patientId)
        {
            _appointmentDal.RemoveAppointmentByDateAndDoctorId(appointmentDateTime,patientId);
        }

        public Appointment GetAppointmentByPatientIdAndDateTime(int patientId, DateTime appDateTime)
        {
           return _appointmentDal.GetAppointmentByPatientIdAndDateTime( patientId, appDateTime);
        }
    }
}
