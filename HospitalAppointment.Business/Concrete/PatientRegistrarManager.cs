using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.Business.Concrete
{
    public class PatientRegistrarManager:GenericManager<PatientRegistrar>,IPatientRegistrarService
    {
        private readonly IPatientRegistrarDal _patientRegistrarDal;
        public PatientRegistrarManager(IGenericDal<PatientRegistrar> genericDal,IPatientRegistrarDal patientRegistrarDal) : base(genericDal)
        {
            _patientRegistrarDal = patientRegistrarDal;
        }

        public List<User> GetPatientRegistrarsWithAllTables()
        {
            return _patientRegistrarDal.GetPatientRegistrarsWithAllTables();
        }

        public User GetPatientRegistrarWithAllTablesByUserId(int id)
        {
            return _patientRegistrarDal.GetPatientRegistrarWithAllTablesByUserId(id);
        }

       
    }
}
