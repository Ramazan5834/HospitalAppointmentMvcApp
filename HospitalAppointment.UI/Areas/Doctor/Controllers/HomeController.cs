using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.UI.StringInfo;
using HospitalAppointment.UI.Tools.ActiveUserContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Areas.Doctor.Controllers
{
    [Authorize(Roles = RoleInfo.Doctor)]
    [Area(AreaInfo.Doctor)]
    public class HomeController : Controller
    {
        private ActiveDoctor _activeDoctor;
        private readonly IMapper _mapper;
        public HomeController(IMapper mapper,IHttpContextAccessor httpContextAccessor,IUserService userService,IDoctorService doctorService)
        {
            _activeDoctor = new ActiveDoctor(httpContextAccessor, userService, doctorService);
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            TempData["ActiveDoctor"] = _activeDoctor.GetActiveDoctor();
            return View();
        }

        public IActionResult MyProfile()
        {
            TempData["ActiveDoctor"] = _activeDoctor.GetActiveDoctor();
            var activeDoctor = _activeDoctor.GetActiveDoctor();
            return View(activeDoctor);
        }
    }
}
