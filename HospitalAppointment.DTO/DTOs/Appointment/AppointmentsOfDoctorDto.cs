using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppointment.DTO.DTOs.Appointment
{
    public class AppointmentsOfDoctorDto
    {
        public DateTime Date { get; set; }
        public DataAccess.Concrete.EntityFrameworkCore.Entities.PatientRegistrar Registrar { get; set; }
        public DataAccess.Concrete.EntityFrameworkCore.Entities.Patient Patient { get; set; }
    }
}
