using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.DataAccess.Interfaces
{
    public interface IBlackListDal:IGenericDal<BlackList>
    {
        List<BlackList> GetPatientBlackListsByPatientId(int id);
        bool CheckInBlackListByPatientId(int id);
    }
}
