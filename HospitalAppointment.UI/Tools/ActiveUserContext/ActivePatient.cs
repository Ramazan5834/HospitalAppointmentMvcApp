using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DTO.DTOs.Patient;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Tools.ActiveUserContext
{
    public class ActivePatient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;

        public ActivePatient(IHttpContextAccessor httpContextAccessor, IUserService userService, IPatientService patientService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _patientService = patientService;
        }

        ActivePatientDto _activePatient = new ActivePatientDto();

        public ActivePatientDto GetActivePatient()
        {
            int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == "UserId").Select(c => c.Value).SingleOrDefault());
           // int patientId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == "PatientId").Select(c => c.Value).SingleOrDefault());
            var activeUser = _userService.GetById(userId);
            var patient = _patientService.GetById(userId);
            _activePatient.UserId = activeUser.Id;
            _activePatient.Tcno = activeUser.Tcno;
            _activePatient.RolId = activeUser.RolId;
            _activePatient.Name = activeUser.Name;
            _activePatient.SurName = activeUser.SurName;
            _activePatient.Email = activeUser.Email;
            _activePatient.BirthDate = activeUser.BirthDate;
            _activePatient.Telephone = activeUser.Telephone;
            _activePatient.Gender = activeUser.Gender;
            _activePatient.MotherName = patient.MotherName;
            _activePatient.FatherName = patient.FatherName;
            return _activePatient;
        }


    }
}
