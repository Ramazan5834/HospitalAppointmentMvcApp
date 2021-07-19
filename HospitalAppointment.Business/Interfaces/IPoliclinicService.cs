using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.Business.Interfaces
{
    public interface IPoliclinicService:IGenericService<Policlinic>
    {
        List<Policlinic> GetDepartmentPoliclinicsByDepartmentId(int id);
    }
}
