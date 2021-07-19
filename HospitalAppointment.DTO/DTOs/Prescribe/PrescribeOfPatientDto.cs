using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppointment.DTO.DTOs.Prescribe
{

    public class PrescribeOfPatientDto
    {
        public int Id { get; set; }
        public string DiseaseName { get; set; }
        public string Medicine { get; set; }
        public string Description { get; set; }
    }
}
