using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.DTO.DTOs.Department
{
    public class DepartmentListDto
    {
        public int Id { get; set; }
        public string DepartmanName { get; set; }
        public List<DataAccess.Concrete.EntityFrameworkCore.Entities.Policlinic> Policlinics { get; set; }
    }
}
