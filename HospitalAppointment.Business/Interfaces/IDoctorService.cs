using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.Business.Interfaces
{
    public interface IDoctorService:IGenericService<Doctor>
    {
        List<User> GetDoctorsWithAllTables();
        List<User> GetDepartmentDoctorsByDepartmentId(int id);
        User GetDoctorWithAllTablesByUserId(int id);
        void DeleteDoctorWithPoliclinicByDoctorId(int id);
    }
}
