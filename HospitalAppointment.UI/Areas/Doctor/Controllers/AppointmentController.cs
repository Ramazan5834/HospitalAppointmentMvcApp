using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DTO.DTOs.Appointment;
using HospitalAppointment.UI.StringInfo;
using HospitalAppointment.UI.Tools.ActiveUserContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Areas.Doctor.Controllers
{
    [Authorize(Roles = RoleInfo.Doctor)]
    [Area(AreaInfo.Doctor)]
    public class AppointmentController : Controller
    {

        private ActiveDoctor _activeDoctor;
        private readonly IMapper _mapper;
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserService userService, IDoctorService doctorService)
        {
            _activeDoctor = new ActiveDoctor(httpContextAccessor, userService, doctorService);
            _mapper = mapper;
            _appointmentService = appointmentService;
        }
        public IActionResult TodayAppointments()
        {
            TempData["ActiveDoctor"] = _activeDoctor.GetActiveDoctor();
            var todayAppointmentsOfDoctor = _mapper.Map<List<AppointmentsOfDoctorDto>>(
                _appointmentService.GetTodayAppointmentsByDoctorId(_activeDoctor.GetActiveDoctor().UserId));
            return View(todayAppointmentsOfDoctor);
        }
    }
}
