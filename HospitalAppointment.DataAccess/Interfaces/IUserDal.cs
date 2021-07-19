using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.DataAccess.Interfaces
{
    public interface IUserDal : IGenericDal<User>
    {
        bool CheckUserforLogin(long tcNo, string password);
        User GetUserByTcNo(long tcNo);
        string GetUserRoleByTcNo(long tcNo);

    }
}
