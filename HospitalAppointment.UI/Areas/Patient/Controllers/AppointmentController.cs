using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DTO.DTOs.Appointment;
using HospitalAppointment.UI.StringInfo;
using HospitalAppointment.UI.Tools.ActiveUserContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HospitalAppointment.UI.Areas.Patient.Controllers
{
    [Authorize(Roles = RoleInfo.Patient)]
    [Area(AreaInfo.Patient)]
    public class AppointmentController : Controller
    {
        private ActivePatient _activePatient;
        private readonly IMapper _mapper;
        private readonly IAppointmentService _appointmentService;
        private readonly IDepartmentService _departmentService;
        private readonly IDoctorService _doctorService;
        private readonly IUserService _userService;
        private readonly IPoliclinicService _policlinicService;
        private readonly IBlackListService _blackListService;
        public AppointmentController(IBlackListService blackListService, IPoliclinicService policlinicService, IDoctorService doctorService, IDepartmentService departmentService, IAppointmentService appointmentService, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserService userService, IPatientService patientService)
        {
            _activePatient = new ActivePatient(httpContextAccessor, userService, patientService);
            _mapper = mapper;
            _appointmentService = appointmentService;
            _departmentService = departmentService;
            _doctorService = doctorService;
            _userService = userService;
            _policlinicService = policlinicService;
            _blackListService = blackListService;
        }

        public IActionResult PastAppointments()
        {
            TempData["ActivePatient"] = _activePatient.GetActivePatient();
            var patientPastAppointments = _mapper.Map<List<AppointmentsOfPatient>>(
                _appointmentService.GetPatientPastAppointmentsByPatientId(_activePatient.GetActivePatient().UserId));
            return View(patientPastAppointments);
        }

        public IActionResult FutureAppointments()
        {
            TempData["ActivePatient"] = _activePatient.GetActivePatient();
            var patientFutureAppointments = _mapper.Map<List<AppointmentsOfPatient>>(
                _appointmentService.GetPatientFutureAppointmentsByPatientId(_activePatient.GetActivePatient().UserId));
            return View(patientFutureAppointments);
        }

        public IActionResult PatientInBlackList()
        {
            TempData["ActivePatient"] = _activePatient.GetActivePatient();
            return View();
        }
        public IActionResult SelectingDepartment()
        {
            if (_blackListService.CheckInBlackListByPatientId(_activePatient.GetActivePatient().UserId))
            {
                var appointmentUserDto = new AppointmentUserDto()
                {
                    UserId = _activePatient.GetActivePatient().UserId,
                    Name = _activePatient.GetActivePatient().Name,
                    SurName = _activePatient.GetActivePatient().SurName,
                };
                TempData["ActivePatient"] = _activePatient.GetActivePatient();
                ViewBag.Departments = new SelectList(_departmentService.GetAll(), "Id", "DepartmanName");
                return View(appointmentUserDto);
            }
            return RedirectToAction("PatientInBlackList");
        }


        public IActionResult SelectingDoctor(AppointmentUserDto appointmentUserDto)
        {
            TempData["ActivePatient"] = _activePatient.GetActivePatient();
            appointmentUserDto.DepartmentName = _departmentService.GetById(appointmentUserDto.DepartmentId).DepartmanName;
            ViewBag.DepartmentDoctors = new SelectList(_doctorService.GetDepartmentDoctorsByDepartmentId(appointmentUserDto.DepartmentId), "Id", "Name");
            return View(appointmentUserDto);
        }

        public IActionResult SelectingDateDay(AppointmentUserDto appointmentUserDto)
        {
            TempData["ActivePatient"] = _activePatient.GetActivePatient();
            var appointmentDoctorUser = _userService.GetById(appointmentUserDto.DoctorUserId);
            appointmentUserDto.DoctorUserName = appointmentDoctorUser.Name;
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

        public IActionResult SelectingDateHourTime(AppointmentUserDto appointmentUserDto)
        {
            TempData["ActivePatient"] = _activePatient.GetActivePatient();
            List<DateTime> existDateHourTimes =
                _appointmentService.GetAppointmentsHourTimesByAppointmentDayAndDoctorId(appointmentUserDto.AppointmentDateTime, appointmentUserDto.DoctorUserId);
            ViewBag.existDateHourTimes = existDateHourTimes;
            return View(appointmentUserDto);
        }

        public IActionResult FormAppointment(AppointmentUserDto appointmentUserDto)
        {
            TempData["ActivePatient"] = _activePatient.GetActivePatient();
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
                RegistrarId = null,
                Confirmed = false,
                CreatingDate = DateTime.Now
            };
            _appointmentService.Add(appointment);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public bool RemoveAppointment(DateTime appointmentDateTime, int patientId)
        {
            try
            {
                _appointmentService.RemoveAppointmentByDateAndDoctorId(appointmentDateTime, patientId);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}
