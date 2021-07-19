using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.Business.Concrete
{
    public class RolManager:GenericManager<Rol>,IRolService
    {
        private readonly IRolDal _rolDal;
        public RolManager(IGenericDal<Rol> genericDal,IRolDal rolDal) : base(genericDal)
        {
            _rolDal = rolDal;
        }

        public Rol GetDoctorRol()
        {
          return  _rolDal.GetDoctorRol();
        }

        public Rol GetSuperAdminRol()
        {
            return _rolDal.GetSuperAdminRol();
        }

        public Rol GetPatientRol()
        {
            return _rolDal.GetPatientRol();
        }

        public Rol GetPatientRegistrarRol()
        {
            return _rolDal.GetPatientRegistrarRol();
        }
    }
}
