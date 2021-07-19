using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.Business.Concrete
{
    public class PrescribeManager : GenericManager<Prescribe>, IPrescribeService
    {
        private readonly IPrescribeDal _prescribeDal;
        public PrescribeManager(IGenericDal<Prescribe> genericDal, IPrescribeDal prescribeDal) : base(genericDal)
        {
            _prescribeDal = prescribeDal;
        }

        public List<Prescribe> GetPatientPrescribeByPatientId(int id)
        {
            return _prescribeDal.GetPatientPrescribeByPatientId(id);
        }
    }
}
