using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DTO.DTOs.PatientRegistrar;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Tools.ActiveUserContext
{
    public class ActivePatientRegistrar
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly IPatientRegistrarService _patientRegistrarService;

        public ActivePatientRegistrar(IHttpContextAccessor httpContextAccessor, IUserService userService, IPatientRegistrarService patientRegistrarService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _patientRegistrarService = patientRegistrarService;

        }
        ActivePatientRegistrarDto _activePatientRegistrar = new ActivePatientRegistrarDto();

        public ActivePatientRegistrarDto GetActivePatientRegistrar()
        {
            int userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == "UserId").Select(c => c.Value).SingleOrDefault());
          //  int patientRegistrarId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == "PatientRegistrarId").Select(c => c.Value).SingleOrDefault());
            var activeUser = _userService.GetById(userId);
            var patientRegistrar = _patientRegistrarService.GetById(userId);
            _activePatientRegistrar.UserId = activeUser.Id;
            _activePatientRegistrar.Tcno = activeUser.Tcno;
            _activePatientRegistrar.RolId = activeUser.RolId;
            _activePatientRegistrar.Name = activeUser.Name;
            _activePatientRegistrar.SurName = activeUser.SurName;
            _activePatientRegistrar.Email = activeUser.Email;
            _activePatientRegistrar.BirthDate = activeUser.BirthDate;
            _activePatientRegistrar.Telephone = activeUser.Telephone;
            _activePatientRegistrar.Gender = activeUser.Gender;
            _activePatientRegistrar.TellerNumber = patientRegistrar.TellerNumber;
            return _activePatientRegistrar;
        }
    }
}
