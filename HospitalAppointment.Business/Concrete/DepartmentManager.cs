using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.Business.Concrete
{
    public class DepartmentManager : GenericManager<Department>, IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        public DepartmentManager(IGenericDal<Department> genericDal, IDepartmentDal departmentDal) : base(genericDal)
        {
            _departmentDal = departmentDal;
        }

        public List<Department> GetWithPoliclinics()
        {
            return _departmentDal.GetWithPoliclinics();
        }

        public List<ViewGetWithPol> GetDepartmentsWithPoliclinics()
        {
            return _departmentDal.GetDepartmentsWithPoliclinics();
        }
    }
}
