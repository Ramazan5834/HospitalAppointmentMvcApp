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
    public class EfPatientRegistrarRepository : EfGenericRepository<PatientRegistrar>, IPatientRegistrarDal
    {
        private readonly HospitalAppBbContext _context;
        public EfPatientRegistrarRepository(HospitalAppBbContext context) : base(context)
        {
            _context = context;
        }

        public List<User> GetPatientRegistrarsWithAllTables()
        {
            return _context.Users.Where(I => I.Rol.RolName == "PatientRegistrar").Include(I => I.PatientRegistrar).ToList();
        }

        public User GetPatientRegistrarWithAllTablesByUserId(int id)
        {
           return _context.Users.Include(I => I.PatientRegistrar).FirstOrDefault(I => I.Id == id);
           
        }
    }
}
