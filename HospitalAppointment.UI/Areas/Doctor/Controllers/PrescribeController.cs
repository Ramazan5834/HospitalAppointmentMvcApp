using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DTO.DTOs.Prescribe;
using HospitalAppointment.UI.StringInfo;
using HospitalAppointment.UI.Tools.ActiveUserContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Areas.Doctor.Controllers
{
    [Authorize(Roles = RoleInfo.Doctor)]
    [Area(AreaInfo.Doctor)]
    public class PrescribeController : Controller
    {
        private ActiveDoctor _activeDoctor;
        private readonly IMapper _mapper;
        private readonly IPrescribeService _prescribeService;
        private readonly IAppointmentService _appointmentService;
        public PrescribeController(IAppointmentService appointmentService, IPrescribeService prescribeService, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserService userService, IDoctorService doctorService)
        {
            _activeDoctor = new ActiveDoctor(httpContextAccessor, userService, doctorService);
            _mapper = mapper;
            _prescribeService = prescribeService;
            _appointmentService = appointmentService;
        }
        public IActionResult CreatePrescribe(int patientId, int doctorId, string appDateTime)
        {
            DateTime appDateTimeLocal = Convert.ToDateTime(appDateTime);
            var nowAppointment = _appointmentService.GetAppointmentByPatientIdAndDateTime(patientId, appDateTimeLocal);
            nowAppointment.Confirmed = true;
            _appointmentService.Update(nowAppointment);
            TempData["ActiveDoctor"] = _activeDoctor.GetActiveDoctor();

            var addPrescribeDto = new PrescribeAddDto()
            {
                PatientId = patientId,
                DoctorId = doctorId
            };
            return View(addPrescribeDto);
        }

        [HttpPost]
        public IActionResult CreatePrescribe(PrescribeAddDto prescribeAddDto)
        {
            var prescribe = _mapper.Map<Prescribe>(prescribeAddDto);
            _prescribeService.Add(prescribe);
            return RedirectToAction("TodayAppointments", "Appointment");
        }
    }
}
