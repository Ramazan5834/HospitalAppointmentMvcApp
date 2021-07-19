using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Context;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppointmentRepository : EfGenericRepository<Appointment>, IAppointmentDal
    {
        private readonly HospitalAppBbContext _context;
        public EfAppointmentRepository(HospitalAppBbContext context) : base(context)
        {
            _context = context;
        }

        public List<DateTime> GetAppointmentsHourTimesByAppointmentDayAndDoctorId(DateTime day, int doctorId)
        {
            List<Appointment> ExistHourTimes = _context.Appointments.Where(I => I.Date.DayOfYear == day.DayOfYear)
                .Where(I => I.DoctorId == doctorId).ToList();
            List<DateTime> AppointmentsHourTimes = new List<DateTime>();
            foreach (var existHourTime in ExistHourTimes)
            {
                AppointmentsHourTimes.Add(existHourTime.Date);
            }
            return AppointmentsHourTimes;
        }

        public List<Appointment> GetPatientRegistrarAppointmentsWithAllTables(int id)
        {
            var appointments = _context.Appointments
                .Include(I => I.Doctor)
                .Include(I => I.Patient)
                .Where(I => I.RegistrarId == id).ToList();
            return appointments;
        }

        public List<Appointment> GetPatientPastAppointmentsByPatientId(int id)
        {
            return _context.Appointments
                .Include(I => I.Doctor)
                .Include(I => I.Registrar)
                .Where(I => I.PatientId == id).Where(I => I.Date <= DateTime.Now)
                .ToList();
        }

        public List<Appointment> GetPatientFutureAppointmentsByPatientId(int id)
        {
            return _context.Appointments
                .Include(I => I.Doctor)
                .Include(I => I.Registrar)
                .Include(I => I.Patient)
                .Where(I => I.PatientId == id).Where(I => I.Date > DateTime.Now)
                .ToList();
        }

        public List<Appointment> GetTodayAppointmentsByDoctorId(int id)
        {
            var today = DateTime.Today.ToShortDateString();
            var doctorAppointments = _context.Appointments
                .Include(I => I.Registrar)
                .Include(I => I.Patient)
                .Where(I => I.DoctorId == id)
                .Where(I => I.Confirmed == false)
                .ToList();
            List<Appointment> todayDoctorAppointments = new List<Appointment>();
            foreach (var doctorAppointment in doctorAppointments)
            {
                if (doctorAppointment.Date.ToShortDateString() == today)
                {
                    todayDoctorAppointments.Add(doctorAppointment);
                }
            }
            return todayDoctorAppointments;
        }

        public void RemoveAppointmentByDateAndDoctorId(DateTime appointmentDateTime, int patientId)
        {
            var appointments = _context.Appointments.Where(I => I.PatientId == patientId).ToList();
            var appointment = appointments.FirstOrDefault(I => I.Date == appointmentDateTime);
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }

        public Appointment GetAppointmentByPatientIdAndDateTime(int patientId, DateTime appDateTime)
        {
            return _context.Appointments.Where(I => I.Date == appDateTime)
                .FirstOrDefault(I => I.PatientId == patientId);
        }
    }
}
