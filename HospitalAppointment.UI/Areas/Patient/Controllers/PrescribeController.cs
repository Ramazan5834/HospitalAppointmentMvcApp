using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DTO.DTOs.Prescribe;
using HospitalAppointment.UI.StringInfo;
using HospitalAppointment.UI.Tools.ActiveUserContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Areas.Patient.Controllers
{
    [Authorize(Roles = RoleInfo.Patient)]
    [Area(AreaInfo.Patient)]
    public class PrescribeController : Controller
    {
        private ActivePatient _activePatient;
        private readonly IMapper _mapper;
        private readonly IPrescribeService _prescribeService;
        public PrescribeController(IPrescribeService prescribeService,IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserService userService, IPatientService patientService)
        {
            _activePatient = new ActivePatient(httpContextAccessor, userService, patientService);
            _mapper = mapper;
            _prescribeService = prescribeService;
        }
        public IActionResult Index()
        {
            TempData["ActivePatient"] = _activePatient.GetActivePatient();
            var patientPrescribes = _mapper.Map<List<PrescribeOfPatientDto>>(
                _prescribeService.GetPatientPrescribeByPatientId(_activePatient.GetActivePatient().UserId));
            return View(patientPrescribes);
        }
    }
}
