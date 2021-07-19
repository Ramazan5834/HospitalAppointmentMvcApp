using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.Business.Interfaces
{
    public interface IPrescribeService:IGenericService<Prescribe>
    {
        List<Prescribe> GetPatientPrescribeByPatientId(int id);
    }
}
