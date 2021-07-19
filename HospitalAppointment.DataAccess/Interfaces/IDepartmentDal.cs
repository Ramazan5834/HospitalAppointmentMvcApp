using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.DataAccess.Interfaces
{
    public interface IDepartmentDal:IGenericDal<Department>
    {
        List<Department> GetWithPoliclinics();
        List<ViewGetWithPol> GetDepartmentsWithPoliclinics();
    }
}
