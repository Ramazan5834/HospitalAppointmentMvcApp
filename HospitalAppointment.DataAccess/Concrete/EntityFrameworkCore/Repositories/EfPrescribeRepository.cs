using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Context;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfPrescribeRepository:EfGenericRepository<Prescribe>,IPrescribeDal
    {
        private readonly HospitalAppBbContext _context;
        public EfPrescribeRepository(HospitalAppBbContext context) : base(context)
        {
            _context = context;
        }

        public List<Prescribe> GetPatientPrescribeByPatientId(int id)
        {
            return _context.Prescribes.Where(I => I.PatientId == id).ToList();
        }
    }
}
