using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.Business.Interfaces
{
    public interface IPatientRegistrarService:IGenericService<PatientRegistrar>
    {
        List<User> GetPatientRegistrarsWithAllTables();
        public User GetPatientRegistrarWithAllTablesByUserId(int id);
    }
}
