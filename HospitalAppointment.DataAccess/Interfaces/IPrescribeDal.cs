using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.DataAccess.Interfaces
{
    public interface IPrescribeDal:IGenericDal<Prescribe>
    {
        List<Prescribe> GetPatientPrescribeByPatientId(int id);
    }
}
