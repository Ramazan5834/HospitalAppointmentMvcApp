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
    public class EfUserRepository : EfGenericRepository<User>, IUserDal
    {
        private readonly HospitalAppBbContext _context;
        public EfUserRepository(HospitalAppBbContext context) : base(context)
        {
            _context = context;
        }

        public bool CheckUserforLogin(long tcNo, string password)
        {
            var user = _context.Users.FirstOrDefault(I => I.Tcno == tcNo);
            if (user != null)
            {
                return user.Password == password ? true : false;
            }
            else
            {
                return false;
            }
        }

        public User GetUserByTcNo(long tcNo)
        {
            return _context.Users.FirstOrDefault(I => I.Tcno == tcNo);
        }

        public string GetUserRoleByTcNo(long tcNo)
        {
            var user = GetUserByTcNo(tcNo);
            return _context.Rols.FirstOrDefault(I => I.Id == user.RolId)?.RolName;
        }

        
    }
}
