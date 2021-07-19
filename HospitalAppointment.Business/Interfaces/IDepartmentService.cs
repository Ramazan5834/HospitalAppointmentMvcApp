using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.Business.Interfaces
{
    public interface IDepartmentService:IGenericService<Department>
    {
        List<Department> GetWithPoliclinics();
        List<ViewGetWithPol> GetDepartmentsWithPoliclinics();
    }
}
