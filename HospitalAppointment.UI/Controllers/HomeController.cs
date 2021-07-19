using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DTO.DTOs.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace HospitalAppointment.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISuperAdminService _superAdminService;
        private readonly IPatientService _patientService;
        private readonly IPatientRegistrarService _patientRegistrarService;
        private readonly IDoctorService _doctorService;
        public HomeController(IUserService userService, ISuperAdminService superAdminService, IPatientService patientService, IDoctorService doctorService, IPatientRegistrarService patientRegistrarService)
        {
            _userService = userService;
            _superAdminService = superAdminService;
            _patientService = patientService;
            _patientRegistrarService = patientRegistrarService;
            _doctorService = doctorService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PatientLogIn()
        {
            return View(new UserLoginDto());
        }

        public IActionResult SuperAdminLogIn()
        {
            return View(new UserLoginDto());
        }

        public IActionResult PatientRegistrarLogIn()
        {
            return View(new UserLoginDto());
        }

        public IActionResult DoctorLogIn()
        {
            return View(new UserLoginDto());
        }


        [HttpPost]
        public IActionResult UserLogIn(UserLoginDto userLoginDto)
        {
            if (_userService.CheckUserforLogin(userLoginDto.Tcno, userLoginDto.Password))
            {
                var user = _userService.GetUserByTcNo(userLoginDto.Tcno);
                var userRole = _userService.GetUserRoleByTcNo(userLoginDto.Tcno);
                var claims = new List<Claim>()
                {
                    new Claim("UserId",user.Id.ToString()),
                };
                if (userRole == "SuperAdmin")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "SuperAdmin"));
                    return LoginWithClaims(claims, "SuperAdmin");
                }
                else if (userRole == "Patient")
                {
                    claims.Add(new Claim(ClaimTypes.Role,"Patient"));
                    return LoginWithClaims(claims, "Patient");
                }
                else if (userRole == "Doctor")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Doctor"));
                    return LoginWithClaims(claims, "Doctor");
                }
                else if (userRole == "PatientRegistrar")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "PatientRegistrar"));
                   return LoginWithClaims(claims, "PatientRegistrar");
                }

                ModelState.AddModelError("", "Bir şeyler yanlış gitti");
                return View(userLoginDto.LoginPath, userLoginDto);
            }
            else
            {
                ModelState.AddModelError("", "TC no yada Parola Hatalı");
                return View(userLoginDto.LoginPath, userLoginDto);
            }

        }

        public IActionResult LoginWithClaims(List<Claim> claims, string areaPath)
        {
            var claimsIdentity = new ClaimsIdentity(claims, "Login");
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return RedirectToAction("Index", "Home", new { area = areaPath });
        }

       
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }


      
    }
}
