using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalAppointment.DTO.DTOs.Patient
{
    public class PatientListDto
    {
        public int Id { get; set; }
        public long TCNo { get; set; }
        public int RolId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public long Telephone { get; set; }
        public bool Gender { get; set; }
        public DataAccess.Concrete.EntityFrameworkCore.Entities.Patient Patient { get; set; }

    }
}
