using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.Business.Concrete
{
    public class UserManager:GenericManager<User>,IUserService
    {
        private readonly IUserDal _userDal;
        public UserManager(IGenericDal<User> genericDal,IUserDal userDal) : base(genericDal)
        {
            _userDal = userDal;
        }

        public bool CheckUserforLogin(long tcNo, string password)
        {
            return _userDal.CheckUserforLogin(tcNo, password);
        }

        public User GetUserByTcNo(long tcNo)
        {
            return _userDal.GetUserByTcNo(tcNo);
        }

        public string GetUserRoleByTcNo(long tcNo)
        {
            return _userDal.GetUserRoleByTcNo(tcNo);
        }
    }
}
