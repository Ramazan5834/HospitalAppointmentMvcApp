using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppointment.DTO.DTOs.Appointment
{
    public class AppointmentsOfPatientRegistrar
    {
        public DateTime Date { get; set; }
        //public DataAccess.Concrete.EntityFrameworkCore.Entities.PatientRegistrar Registrar { get; set; }
        public DataAccess.Concrete.EntityFrameworkCore.Entities.Doctor Doctor { get; set; }
        public DataAccess.Concrete.EntityFrameworkCore.Entities.Patient Patient { get; set; }
    }
}
