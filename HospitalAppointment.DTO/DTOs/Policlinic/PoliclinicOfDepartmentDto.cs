using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppointment.DTO.DTOs.Policlinic
{
    public class PoliclinicOfDepartmentDto
    {
        public int Id { get; set; }
        public string PoliclinicName { get; set; }
        public int DepartmentId { get; set; }
    }
}
