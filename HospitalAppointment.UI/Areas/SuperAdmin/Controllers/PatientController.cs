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

namespace HospitalAppointment.UI.Areas.SuperAdmin.Controllers
{
    [Authorize(Roles = RoleInfo.SuperAdmin)]
    [Area(AreaInfo.SuperAdmin)]
    public class PatientController : Controller
    {
        private readonly ActiveSuperAdmin _activeSuperAdmin;
        private readonly IMapper _mapper;
        private readonly IRolService _rolService;
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService, IMapper mapper, IRolService rolService, IHttpContextAccessor httpContextAccessor, IUserService userService, ISuperAdminService superAdminService)
        {
            _activeSuperAdmin = new ActiveSuperAdmin(httpContextAccessor, userService, superAdminService);
            _userService = userService;
            _rolService = rolService;
            _mapper = mapper;
            _patientService = patientService;
        }
        public IActionResult Index()
        {
            TempData["ActiveSuperAdmin"] = _activeSuperAdmin.GetActiveSuperAdmin();
            var patientListDto = _mapper.Map<List<PatientListDto>>(_patientService.GetPatientsWithAllTables());
            return View(patientListDto);
        }

        public IActionResult CreatePatient()
        {
            TempData["ActiveSuperAdmin"] = _activeSuperAdmin.GetActiveSuperAdmin();
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
            var patient = new DataAccess.Concrete.EntityFrameworkCore.Entities.Patient()
            {
                Id = userId,
                MotherName = patientAddDto.MotherName,
                FatherName = patientAddDto.FatherName,
                SuperAdminId = _activeSuperAdmin.GetActiveSuperAdmin().UserId
            };
            _patientService.Add(patient);
            return RedirectToAction("Index", "Patient");
        }

        [HttpPost]
        public bool RemovePatient(int id)
        {
            try
            {
                _userService.Remove(_userService.GetById(id));
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public IActionResult UpdatePatient(int patientId)
        {
            TempData["ActiveSuperAdmin"] = _activeSuperAdmin.GetActiveSuperAdmin();
            var patientUpdateDto =
                _mapper.Map<PatientUpdateDto>(_patientService.GetPatientWithAllTableByUserId(patientId));
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
            return RedirectToAction("Index", "Patient");
        }



    }
}
