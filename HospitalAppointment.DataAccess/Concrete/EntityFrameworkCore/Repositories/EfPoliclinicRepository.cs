using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Context;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfPoliclinicRepository:EfGenericRepository<Policlinic>,IPoliclinicDal
    {
        private readonly HospitalAppBbContext _context;
        public EfPoliclinicRepository(HospitalAppBbContext context) : base(context)
        {
            _context = context;
        }

        public List<Policlinic> GetDepartmentPoliclinicsByDepartmentId(int id)
        {
            return _context.Policlinics.Where(I => I.DepartmentId == id).ToList();
        }
    }
}
