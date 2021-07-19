using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.Business.Interfaces
{
    public interface ISuperAdminService:IGenericService<SuperAdmin>
    {
        SuperAdmin GetSuperAdminByUserId(int id);
    }
}
