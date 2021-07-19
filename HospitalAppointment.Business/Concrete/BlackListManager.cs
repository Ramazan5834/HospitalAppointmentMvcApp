using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.Business.Concrete
{
    public class BlackListManager:GenericManager<BlackList>,IBlackListService
    {
        private readonly IBlackListDal _blackListDal;
        public BlackListManager(IGenericDal<BlackList> genericDal,IBlackListDal blackListDal) : base(genericDal)
        {
            _blackListDal = blackListDal;
        }

        public List<BlackList> GetPatientBlackListsByPatientId(int id)
        {
            return _blackListDal.GetPatientBlackListsByPatientId(id);
        }

        public bool CheckInBlackListByPatientId(int id)
        {
            return _blackListDal.CheckInBlackListByPatientId(id);
        }
    }
}
