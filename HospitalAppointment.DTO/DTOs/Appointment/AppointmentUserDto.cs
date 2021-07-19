using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppointment.DTO.DTOs.Appointment
{
    public class AppointmentUserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        //public int DoctorId { get; set; }
        public int PoliclinicId { get; set; }
        public string PoliclinicName { get; set; }
        public int DoctorUserId { get; set; }
        public string DoctorUserName { get; set; }
        public DateTime AppointmentDateTime { get; set; }
    }
}
