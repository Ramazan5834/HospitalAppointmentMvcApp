using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.Business.Concrete
{
    public class PoliclinicManager:GenericManager<Policlinic>,IPoliclinicService
    {
        private readonly IPoliclinicDal _policlinicDal;
        public PoliclinicManager(IGenericDal<Policlinic> genericDal,IPoliclinicDal policlinicDal) : base(genericDal)
        {
            _policlinicDal = policlinicDal;
        }

        public List<Policlinic> GetDepartmentPoliclinicsByDepartmentId(int id)
        {
            return _policlinicDal.GetDepartmentPoliclinicsByDepartmentId(id);
        }
    }
}
