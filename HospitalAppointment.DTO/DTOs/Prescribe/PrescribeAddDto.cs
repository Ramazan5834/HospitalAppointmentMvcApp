using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppointment.DTO.DTOs.Prescribe
{
    public class PrescribeAddDto
    {
        public string DiseaseName { get; set; }
        public string Medicine { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
    }
}
