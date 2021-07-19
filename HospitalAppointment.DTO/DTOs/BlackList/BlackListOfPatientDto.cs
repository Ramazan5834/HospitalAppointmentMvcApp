using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppointment.DTO.DTOs.BlackList
{

    public class BlackListOfPatientDto
    {
        public int Id { get; set; }
        public DateTime DeceptionCount { get; set; }
        public string Description { get; set; }
    }
}
