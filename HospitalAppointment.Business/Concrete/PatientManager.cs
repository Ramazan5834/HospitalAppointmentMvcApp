using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.Business.Concrete
{
    public class PatientManager:GenericManager<Patient>,IPatientService
    {
        private readonly IPatientDal _patientDal;
        public PatientManager(IGenericDal<Patient> genericDal,IPatientDal patientDal) : base(genericDal)
        {
            _patientDal = patientDal;
        }

        public List<User> GetPatientsWithAllTables()
        {
            return _patientDal.GetPatientsWithAllTables();
        }

        public User CheckAndGetPatientByTcNo(long tc)
        {
            return _patientDal.CheckAndGetPatientByTcNo(tc);
        }

        public User GetPatientWithAllTableByUserId(int id)
        {
            return _patientDal.GetPatientWithAllTableByUserId(id);
        }

        public User GetPatientWithAllTablesByTcNo(long tcNo)
        {
            return _patientDal.GetPatientWithAllTablesByTcNo(tcNo);
        }
    }
}
