using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Context;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfRolRepository:EfGenericRepository<Rol>,IRolDal
    {
        private readonly HospitalAppBbContext _context;

        public EfRolRepository(HospitalAppBbContext context) : base(context)
        {
            _context = context;
        }

        public Rol GetDoctorRol()
        {
            return _context.Rols.FirstOrDefault(I => I.RolName == "Doctor");
        }

        public Rol GetSuperAdminRol()
        {
            return _context.Rols.FirstOrDefault(I => I.RolName == "SuperAdmin");
        }
        public Rol GetPatientRol()
        {
            return _context.Rols.FirstOrDefault(I => I.RolName == "Patient");
        }
        public Rol GetPatientRegistrarRol()
        {
            return _context.Rols.FirstOrDefault(I => I.RolName == "PatientRegistrar");
        }

    }
}
