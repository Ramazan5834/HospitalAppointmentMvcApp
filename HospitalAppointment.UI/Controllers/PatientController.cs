using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DTO.DTOs.Patient;

namespace HospitalAppointment.UI.Controllers
{
    public class PatientController : Controller
    {
        private readonly IRolService _rolService;
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;
        private readonly ISuperAdminService _superAdminService;
        public PatientController(ISuperAdminService superAdminService,IRolService rolService, IUserService userService, IPatientService patientService)
        {
            _rolService = rolService;
            _userService = userService;
            _patientService = patientService;
            _superAdminService = superAdminService;
        }
        public IActionResult CreatePatient()
        {
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
            return RedirectToAction("Index", "Home");
        }

    }
}
