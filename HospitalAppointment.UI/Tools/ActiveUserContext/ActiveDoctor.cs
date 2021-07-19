using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DTO.DTOs.Doctor;
using HospitalAppointment.DTO.DTOs.Patient;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Tools.ActiveUserContext
{
    public class ActiveDoctor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IDoctorService _doctorService;

        public ActiveDoctor(IHttpContextAccessor httpContextAccessor, IUserService userService, IDoctorService doctorService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _doctorService = doctorService;
        }

        ActiveDoctorDto _activeDoctor = new ActiveDoctorDto();

        public ActiveDoctorDto GetActiveDoctor()
        {
            int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == "UserId").Select(c => c.Value).SingleOrDefault());
            // int patientId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == "PatientId").Select(c => c.Value).SingleOrDefault());
            var activeUser = _userService.GetById(userId);
            var doctor = _doctorService.GetById(userId);
            _activeDoctor.UserId = activeUser.Id;
            _activeDoctor.Tcno = activeUser.Tcno;
            _activeDoctor.RolId = activeUser.RolId;
            _activeDoctor.Name = activeUser.Name;
            _activeDoctor.SurName = activeUser.SurName;
            _activeDoctor.Email = activeUser.Email;
            _activeDoctor.BirthDate = activeUser.BirthDate;
            _activeDoctor.Telephone = activeUser.Telephone;
            _activeDoctor.Gender = activeUser.Gender;
            _activeDoctor.Apellation = doctor.Apellation;
            _activeDoctor.DepartmentId = doctor.DepartmentId;
            return _activeDoctor;
        }
    }
}
