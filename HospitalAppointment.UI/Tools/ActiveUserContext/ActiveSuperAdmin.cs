using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DTO.DTOs.SuperAdmin;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Tools.ActiveUserContext
{
    public class ActiveSuperAdmin
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        private readonly ISuperAdminService _superAdminService;

        public ActiveSuperAdmin(IHttpContextAccessor httpContextAccessor,IUserService userService,ISuperAdminService superAdminService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
            _superAdminService = superAdminService;

        }
        ActiveSuperAdminDto _activeSuperAdmin = new ActiveSuperAdminDto();

        public ActiveSuperAdminDto GetActiveSuperAdmin()
        {
            int userId = Convert.ToInt32( _httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == "UserId").Select(c => c.Value).SingleOrDefault());
           // int superAdminId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == "SuperAdminId").Select(c => c.Value).SingleOrDefault());
            var activeUser = _userService.GetById(userId);
            var superAdmin = _superAdminService.GetById(userId);
            _activeSuperAdmin.UserId = activeUser.Id;
            _activeSuperAdmin.Tcno = activeUser.Tcno;
            _activeSuperAdmin.RolId = activeUser.RolId;
            _activeSuperAdmin.Name = activeUser.Name;
            _activeSuperAdmin.SurName = activeUser.SurName;
            _activeSuperAdmin.Email = activeUser.Email;
            _activeSuperAdmin.BirthDate = activeUser.BirthDate;
            _activeSuperAdmin.Telephone = activeUser.Telephone;
            _activeSuperAdmin.Gender = activeUser.Gender;
            _activeSuperAdmin.Apellation = superAdmin.Apellation;
            return _activeSuperAdmin;
        }

    }

}
