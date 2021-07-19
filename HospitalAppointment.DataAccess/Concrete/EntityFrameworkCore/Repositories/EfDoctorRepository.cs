using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Context;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfDoctorRepository : EfGenericRepository<Doctor>, IDoctorDal
    {
        private readonly HospitalAppBbContext _context;
        public EfDoctorRepository(HospitalAppBbContext context) : base(context)
        {
            _context = context;
        }

        public List<User> GetDoctorsWithAllTables()
        {
            return _context.Users.Where(I => I.Rol.RolName == "Doctor").Include(I => I.Doctor).ThenInclude(I => I.Department)
                .ThenInclude(I => I.Policlinics).ToList();
        }

        public List<User> GetDepartmentDoctorsByDepartmentId(int id)
        {
            var doctors = _context.Users.Include(I => I.Doctor).Where(I => I.Doctor.DepartmentId == id).ToList();
            return doctors;
        }

        public User GetDoctorWithAllTablesByUserId(int id)
        {
            return _context.Users.Include(I => I.Doctor)
                .ThenInclude(I=>I.Policlinic)
                .FirstOrDefault(I => I.Id == id);

        }

        public void DeleteDoctorWithPoliclinicByDoctorId(int id)
        {
            var doctorPoliclinic = _context.Policlinics.FirstOrDefault(I => I.Id == id);
            _context.Policlinics.Remove(doctorPoliclinic);
            var doctorUser = _context.Users.FirstOrDefault(I => I.Id == id);
            _context.Users.Remove(doctorUser);
            _context.SaveChanges();
        }


    }
}
