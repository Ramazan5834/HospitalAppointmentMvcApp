using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.Business.Interfaces
{
    public interface IUserService:IGenericService<User>
    {
        bool CheckUserforLogin(long tcNo, string password);
        User GetUserByTcNo(long tcNo);
        string GetUserRoleByTcNo(long tcNo);
    }
}
