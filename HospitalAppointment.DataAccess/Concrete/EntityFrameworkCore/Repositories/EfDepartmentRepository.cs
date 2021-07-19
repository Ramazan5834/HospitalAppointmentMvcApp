using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Context;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfDepartmentRepository : EfGenericRepository<Department>, IDepartmentDal
    {
        private readonly HospitalAppBbContext _context;
        public EfDepartmentRepository(HospitalAppBbContext context) : base(context)
        {
            _context = context;
        }

        public List<Department> GetWithPoliclinics()
        {
            return  _context.Departments.Include(I => I.Policlinics).ToList();
        }

        public List<ViewGetWithPol> GetDepartmentsWithPoliclinics()
        {
            return _context.ViewGetWithPols.ToList();
        }

    }
}
