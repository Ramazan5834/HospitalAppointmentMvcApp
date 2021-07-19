using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.Business.Concrete
{
    public class DoctorManager:GenericManager<Doctor>,IDoctorService
    {
        private readonly IDoctorDal _doctorDal;
        public DoctorManager(IGenericDal<Doctor> genericDal,IDoctorDal doctorDal) : base(genericDal)
        {
            _doctorDal = doctorDal;
        }

        public List<User> GetDoctorsWithAllTables()
        {
            return _doctorDal.GetDoctorsWithAllTables();
        }

        public List<User> GetDepartmentDoctorsByDepartmentId(int id)
        {
            return _doctorDal.GetDepartmentDoctorsByDepartmentId(id);
        }

        public User GetDoctorWithAllTablesByUserId(int id)
        {
            return _doctorDal.GetDoctorWithAllTablesByUserId(id);
        }

        public void DeleteDoctorWithPoliclinicByDoctorId(int id)
        {
            _doctorDal.DeleteDoctorWithPoliclinicByDoctorId(id);
        }
    }
}
