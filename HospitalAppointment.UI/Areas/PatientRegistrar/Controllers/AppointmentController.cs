using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DTO.DTOs.Appointment;
using HospitalAppointment.UI.StringInfo;
using HospitalAppointment.UI.Tools.ActiveUserContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;

namespace HospitalAppointment.UI.Areas.PatientRegistrar.Controllers
{
    [Authorize(Roles = RoleInfo.PatientRegistrar)]
    [Area(AreaInfo.PatientRegistrar)]
    public class AppointmentController : Controller
    {
        private ActivePatientRegistrar _activePatientRegistrar;
        private readonly IPatientService _patientService;
        private readonly IDepartmentService _departmentService;
        private readonly IDoctorService _doctorService;
        private readonly IPoliclinicService _policlinicService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IAppointmentService _appointmentService;
        private readonly IBlackListService _blackListService;
        public AppointmentController(IBlackListService blackListService, IAppointmentService appointmentService, IMapper mapper, IPoliclinicService policlinicService, IDoctorService doctorService, IDepartmentService departmentService, IPatientService patientService, IHttpContextAccessor httpContextAccessor, IUserService userService, IPatientRegistrarService patientRegistrarService)
        {
            _activePatientRegistrar = new ActivePatientRegistrar(httpContextAccessor, userService, patientRegistrarService);
            _patientService = patientService;
            _departmentService = departmentService;
            _doctorService = doctorService;
            _policlinicService = policlinicService;
            _mapper = mapper;
            _userService = userService;
            _appointmentService = appointmentService;
            _blackListService = blackListService;
        }

        public IActionResult PatientInBlackList()
        {
            TempData["ActivePatientRegistrar"] = _activePatientRegistrar.GetActivePatientRegistrar();
            return View();
        }
        public IActionResult SelectingPatient()
        {
            TempData["ActivePatientRegistrar"] = _activePatientRegistrar.GetActivePatientRegistrar();
            return View();
        }

        [HttpPost]
        public IActionResult SelectingPatient(long tc)
        {
            var checkedPatientUser = _patientService.CheckAndGetPatientByTcNo(tc);
            if (checkedPatientUser != null)
            {
                if (_blackListService.CheckInBlackListByPatientId(checkedPatientUser.Id))
                {
                    var appointmentUserDto = new AppointmentUserDto()
                    {
                        UserId = checkedPatientUser.Id,
                        Name = checkedPatientUser.Name,
                        SurName = checkedPatientUser.SurName,
                    };
                    return RedirectToAction("SelectingDepartment", appointmentUserDto);
                }
                else
                {
                    return RedirectToAction("PatientInBlackList");
                }
            }
            else
            {
                TempData["ActivePatientRegistrar"] = _activePatientRegistrar.GetActivePatientRegistrar();
                ModelState.AddModelError("", "Hasta Bulunamadı");
                return View(tc);
            }

        }

        public IActionResult SelectingDepartment(AppointmentUserDto appointmentUserDto)
        {
            TempData["ActivePatientRegistrar"] = _activePatientRegistrar.GetActivePatientRegistrar();
            ViewBag.Departments = new SelectList(_departmentService.GetAll(), "Id", "DepartmanName");
            return View(appointmentUserDto);
        }


        [HttpPost]
        public IActionResult SelectingDoctor(AppointmentUserDto appointmentUserDto)
        {
            TempData["ActivePatientRegistrar"] = _activePatientRegistrar.GetActivePatientRegistrar();
            appointmentUserDto.DepartmentName = _departmentService.GetById(appointmentUserDto.DepartmentId).DepartmanName;
            ViewBag.DepartmentDoctors = new SelectList(_doctorService.GetDepartmentDoctorsByDepartmentId(appointmentUserDto.DepartmentId), "Id", "Name");
            return View(appointmentUserDto);
        }

        [HttpPost]
        public IActionResult SelectingDateDay(AppointmentUserDto appointmentUserDto)
        {
            TempData["ActivePatientRegistrar"] = _activePatientRegistrar.GetActivePatientRegistrar();
            var appointmentDoctorUser = _userService.GetById(appointmentUserDto.DoctorUserId);
            appointmentUserDto.DoctorUserName = appointmentDoctorUser.Name;
            //  var appointmentDoctor = _doctorService.GetDoctorByUserId(appointmentDoctorUser.Id);
            // appointmentUserDto.DoctorId = appointmentDoctor.Id;
            var doctorPoliclinic = _policlinicService.GetById(appointmentUserDto.DoctorUserId);
            appointmentUserDto.PoliclinicId = doctorPoliclinic.Id;
            appointmentUserDto.PoliclinicName = doctorPoliclinic.PoliclinicName;
            List<DateTime> dateDays = new List<DateTime>();

            int i = 1;
            while (true)
            {
                if (DateTime.Today.AddDays(i).DayOfWeek != DayOfWeek.Saturday && DateTime.Today.AddDays(i).DayOfWeek != DayOfWeek.Sunday)
                {
                    dateDays.Add(DateTime.Today.AddDays(i));
                }

                if (dateDays.Count == 7)
                {
                    break;
                }
                i++;
            }
            ViewBag.DateDays = dateDays;
            return View(appointmentUserDto);
        }

        [HttpPost]
        public IActionResult SelectingDateHourTime(AppointmentUserDto appointmentUserDto)
        {
            TempData["ActivePatientRegistrar"] = _activePatientRegistrar.GetActivePatientRegistrar();
            List<DateTime> existDateHourTimes =
                _appointmentService.GetAppointmentsHourTimesByAppointmentDayAndDoctorId(appointmentUserDto.AppointmentDateTime, appointmentUserDto.DoctorUserId);
            ViewBag.existDateHourTimes = existDateHourTimes;
            return View(appointmentUserDto);
        }

        [HttpPost]
        public IActionResult FormAppointment(AppointmentUserDto appointmentUserDto)
        {
            TempData["ActivePatientRegistrar"] = _activePatientRegistrar.GetActivePatientRegistrar();
            return View(appointmentUserDto);
        }


        [HttpPost]
        public IActionResult CreateAppointment(AppointmentUserDto appointmentUserDto)
        {

            Appointment appointment = new Appointment()
            {
                DoctorId = appointmentUserDto.DoctorUserId,
                Date = appointmentUserDto.AppointmentDateTime,
                PatientId = appointmentUserDto.UserId,
                RegistrarId = _activePatientRegistrar.GetActivePatientRegistrar().UserId,
                Confirmed = false,
                CreatingDate = DateTime.Now
            };
            _appointmentService.Add(appointment);
            return RedirectToAction("Index", "Home");
        }
    }
}
