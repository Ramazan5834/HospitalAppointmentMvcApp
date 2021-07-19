using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.DataAccess.Interfaces
{
    public interface IRolDal : IGenericDal<Rol>
    {
        Rol GetDoctorRol();
        Rol GetSuperAdminRol();
        Rol GetPatientRol();
        Rol GetPatientRegistrarRol();
    }
}
