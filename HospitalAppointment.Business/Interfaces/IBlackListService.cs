using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.Business.Interfaces
{
    public interface IBlackListService:IGenericService<BlackList>
    {
        List<BlackList> GetPatientBlackListsByPatientId(int id);
        bool CheckInBlackListByPatientId(int id);
    }
}
