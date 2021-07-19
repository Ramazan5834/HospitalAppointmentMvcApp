using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppointment.DTO.DTOs.User
{
    public class UserLoginDto
    {
        public long Tcno { get; set; }
        public string Password { get; set; }
        public string LoginPath { get; set; }
    }
}
