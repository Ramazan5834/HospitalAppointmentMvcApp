using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.DataAccess.Interfaces
{
    public interface IPoliclinicDal:IGenericDal<Policlinic>
    {
        List<Policlinic> GetDepartmentPoliclinicsByDepartmentId(int id);
    }
}
