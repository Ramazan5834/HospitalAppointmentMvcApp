using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAppointment.Business.Concrete;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DTO.DTOs.BlackList;
using HospitalAppointment.UI.StringInfo;
using HospitalAppointment.UI.Tools.ActiveUserContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Areas.Patient.Controllers
{
    [Authorize(Roles = RoleInfo.Patient)]
    [Area(AreaInfo.Patient)]
    public class BlackListController : Controller
    {

        private ActivePatient _activePatient;
        private readonly IMapper _mapper;
        private readonly IBlackListService _blackListService;
        public BlackListController(IBlackListService blackListService,IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserService userService, IPatientService patientService)
        {
            _activePatient = new ActivePatient(httpContextAccessor, userService, patientService);
            _mapper = mapper;
            _blackListService = blackListService;
        }
        public IActionResult Index()
        {
            TempData["ActivePatient"] = _activePatient.GetActivePatient();
            var patientBlackLists = _mapper.Map<List<BlackListOfPatientDto>>(
                _blackListService.GetPatientBlackListsByPatientId(_activePatient.GetActivePatient().UserId));
            return View(patientBlackLists);
        }
    }
}
