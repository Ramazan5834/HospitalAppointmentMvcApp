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

namespace HospitalAppointment.UI.Areas.PatientRegistrar.Controllers
{
    [Authorize(Roles = RoleInfo.PatientRegistrar)]
    [Area(AreaInfo.PatientRegistrar)]
    public class HomeController : Controller
    {

        private ActivePatientRegistrar _activePatientRegistrar;
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;
        public HomeController(IMapper mapper, IAppointmentService appointmentService, IHttpContextAccessor httpContextAccessor, IUserService userService, IPatientRegistrarService patientRegistrarService)
        {
            _activePatientRegistrar = new ActivePatientRegistrar(httpContextAccessor, userService, patientRegistrarService);
            _appointmentService = appointmentService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["ActivePatientRegistrar"] = _activePatientRegistrar.GetActivePatientRegistrar();
            var patientRegistrarAppointments = _mapper.Map<List<AppointmentsOfPatientRegistrar>>(_appointmentService
                .GetPatientRegistrarAppointmentsWithAllTables(_activePatientRegistrar
                .GetActivePatientRegistrar().UserId));
            return View(patientRegistrarAppointments);
        }

        public IActionResult MyProfile()
        {
            TempData["ActivePatientRegistrar"] = _activePatientRegistrar.GetActivePatientRegistrar();
            var activePatientRegistrar = _activePatientRegistrar.GetActivePatientRegistrar();
            return View(activePatientRegistrar);
        }
    }
}
