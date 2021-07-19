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
    public class EfPatientRepository : EfGenericRepository<Patient>, IPatientDal
    {
        private readonly HospitalAppBbContext _context;
        public EfPatientRepository(HospitalAppBbContext context) : base(context)
        {
            _context = context;
        }

        public List<User> GetPatientsWithAllTables()
        {
            return _context.Users.Where(I=>I.Rol.RolName == "Patient").Include(I=>I.Patient).ToList();
        }

        public User CheckAndGetPatientByTcNo(long tc)
        {
            var user = _context.Users.FirstOrDefault(I => I.Tcno == tc);
            if (user != null)
            {
                var userRoleName = _context.Rols.FirstOrDefault(I => I.Id == user.RolId)?.RolName;
                if (userRoleName == "Patient")
                {
                    return user;
                }
            }
            else
            {
                return null;
            }
            return null;
        }

        public User GetPatientWithAllTableByUserId(int id)
        {
            return _context.Users.Include(I => I.Patient).FirstOrDefault(I => I.Id == id);
        }

        public User GetPatientWithAllTablesByTcNo(long tcNo)
        {
            return _context.Users.Include(I => I.Patient).FirstOrDefault(I => I.Tcno == tcNo);
        }

    }
}
