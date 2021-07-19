using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Context;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfSuperAdminRepository:EfGenericRepository<SuperAdmin>,ISuperAdminDal
    {
        private readonly HospitalAppBbContext _context;
        public EfSuperAdminRepository(HospitalAppBbContext context) : base(context)
        {
            _context = context;
        }

        public SuperAdmin GetSuperAdminByUserId(int id)
        {
            return _context.SuperAdmins.FirstOrDefault(I => I.Id == id);
        }
    }
}
