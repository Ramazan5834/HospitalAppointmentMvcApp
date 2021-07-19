using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DTO.DTOs.Patient;
using HospitalAppointment.UI.StringInfo;
using HospitalAppointment.UI.Tools.ActiveUserContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Areas.PatientRegistrar.Controllers
{
    [Authorize(Roles = RoleInfo.PatientRegistrar)]
    [Area(AreaInfo.PatientRegistrar)]
    public class PatientController : Controller
    {
        private ActivePatientRegistrar _activePatientRegistrar;
        private readonly IRolService _rolService;
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;
        private readonly ISuperAdminService _superAdminService;
        private readonly IMapper _mapper;
        public PatientController(ISuperAdminService superAdminService,IMapper mapper,IPatientService patientService,IRolService rolService,IHttpContextAccessor httpContextAccessor, IUserService userService, IPatientRegistrarService patientRegistrarService)
        {
            _activePatientRegistrar = new ActivePatientRegistrar(httpContextAccessor, userService, patientRegistrarService);
            _rolService = rolService;
            _userService = userService;
            _patientService = patientService;
            _mapper = mapper;
            _superAdminService = superAdminService;
        }
  

        public IActionResult CreatePatient()
        {
            TempData["ActivePatientRegistrar"] = _activePatientRegistrar.GetActivePatientRegistrar();
            var patientAddDto = new PatientAddDto() { RolId = _rolService.GetPatientRol().Id };
            return View(patientAddDto);
        }

        [HttpPost]
        public IActionResult CreatePatient(PatientAddDto patientAddDto)
        {
            var patientUser = new User()
            {
                Tcno = patientAddDto.Tcno,
                RolId = patientAddDto.RolId,
                Name = patientAddDto.Name,
                SurName = patientAddDto.SurName,
                Email = patientAddDto.Email,
                BirthDate = patientAddDto.BirthDate,
                Telephone = patientAddDto.Telephone,
                Gender = patientAddDto.Gender,
                Password = patientAddDto.Password
            };
            int userId = _userService.AddWithRetObject(patientUser).Id;
            var adminId = _superAdminService.GetAll().FirstOrDefault().Id;
            var patient = new DataAccess.Concrete.EntityFrameworkCore.Entities.Patient()
            {
                Id = userId,
                MotherName = patientAddDto.MotherName,
                FatherName = patientAddDto.FatherName,
                SuperAdminId = adminId
            };
            _patientService.Add(patient);
            return RedirectToAction("Index","Home");
        }

        public IActionResult UpdatePatientForm()
        {
            TempData["ActivePatientRegistrar"] = _activePatientRegistrar.GetActivePatientRegistrar();
            return View();
        }

        public IActionResult UpdatePatient(long tc)
        {
            TempData["ActivePatientRegistrar"] = _activePatientRegistrar.GetActivePatientRegistrar();
            var patientUpdateDto = _mapper.Map<PatientUpdateDto>(_patientService.GetPatientWithAllTablesByTcNo(tc));
            return View(patientUpdateDto);
        }

        [HttpPost]
        public IActionResult UpdatePatient(PatientUpdateDto patientUpdateDto)
        {
            var patientUser = new DataAccess.Concrete.EntityFrameworkCore.Entities.User()
            {
                Id = patientUpdateDto.Id,
                Tcno = patientUpdateDto.Tcno,
                RolId = patientUpdateDto.RolId,
                Name = patientUpdateDto.Name,
                SurName = patientUpdateDto.SurName,
                Email = patientUpdateDto.Email,
                BirthDate = patientUpdateDto.BirthDate,
                Telephone = patientUpdateDto.Telephone,
                Gender = patientUpdateDto.Gender,
                Password = patientUpdateDto.Password
            };
            var patient = new DataAccess.Concrete.EntityFrameworkCore.Entities.Patient()
            {
                Id = patientUpdateDto.Id,
                MotherName = patientUpdateDto.Patient.MotherName,
                FatherName = patientUpdateDto.Patient.FatherName,
                SuperAdminId = patientUpdateDto.Patient.SuperAdminId
            };
            _userService.Update(patientUser);
            _patientService.Update(patient);
            return RedirectToAction("Index", "Home");
        }

    }
}
