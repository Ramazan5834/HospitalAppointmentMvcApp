using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

namespace HospitalAppointment.Business.Interfaces
{
    public interface IRolService:IGenericService<Rol>
    {
        Rol GetDoctorRol();
        Rol GetSuperAdminRol();
        Rol GetPatientRol();
        Rol GetPatientRegistrarRol();
    }
}
