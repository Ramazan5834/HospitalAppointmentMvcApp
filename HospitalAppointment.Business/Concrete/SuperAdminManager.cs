using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.Business.Concrete
{
    public class SuperAdminManager:GenericManager<SuperAdmin>,ISuperAdminService
    {
        private readonly ISuperAdminDal _superAdminDal;
        public SuperAdminManager(IGenericDal<SuperAdmin> genericDal,ISuperAdminDal superAdminDal) : base(genericDal)
        {
            _superAdminDal = superAdminDal;
        }

        public SuperAdmin GetSuperAdminByUserId(int id)
        {
            return _superAdminDal.GetSuperAdminByUserId(id);
        }
    }
}
