using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppointment.DTO.DTOs.BlackList
{
    public class BlackListAddDto
    {
        public int Id { get; set; }
        public DateTime DeceptionCount { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
    }
}
