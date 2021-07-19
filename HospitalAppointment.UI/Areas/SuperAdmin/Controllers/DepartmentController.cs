using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DTO.DTOs.Department;
using HospitalAppointment.UI.CustomFilters;
using HospitalAppointment.UI.StringInfo;
using HospitalAppointment.UI.Tools.ActiveUserContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Areas.SuperAdmin.Controllers
{
    [Authorize(Roles = RoleInfo.SuperAdmin)]
    [Area(AreaInfo.SuperAdmin)]
    public class DepartmentController : Controller
    {
        private readonly ActiveSuperAdmin _activeSuperAdmin;
        private readonly IDepartmentService _departmentService;
        private readonly IPoliclinicService _policlinicService;
        private readonly IMapper _mapper;
        public DepartmentController(IPoliclinicService policlinicService, IMapper mapper, IDepartmentService departmentService, IHttpContextAccessor httpContextAccessor, IUserService userService, ISuperAdminService superAdminService)
        {
            _activeSuperAdmin = new ActiveSuperAdmin(httpContextAccessor, userService, superAdminService);
            _departmentService = departmentService;
            _mapper = mapper;
            _policlinicService = policlinicService;
        }

        public IActionResult Index()
        {
            TempData["ActiveSuperAdmin"] = _activeSuperAdmin.GetActiveSuperAdmin();
            //var departments = _mapper.Map<List<DepartmentListDto>>(_departmentService.GetWithPoliclinics());
            var allDepartments = _departmentService.GetAll();
            ViewData["depPoliclinics"] = _departmentService.GetDepartmentsWithPoliclinics();
            var departments = _mapper.Map<List<DepartmentListDto>>(allDepartments);
            return View(departments);
        }
        public IActionResult CreateDepartment()
        {
            TempData["ActiveSuperAdmin"] = _activeSuperAdmin.GetActiveSuperAdmin();
            return View(new DepartmentAddDto());
        }

        [HttpPost]
        public IActionResult CreateDepartment(DepartmentAddDto departmentDto)
        {
            _departmentService.Add(_mapper.Map<Department>(departmentDto));
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public bool RemoveDepartment(int id)
        {
            try
            {
                _departmentService.Remove(_departmentService.GetById(id));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public IActionResult UpdateDepartment(int departmentId)
        {
            TempData["ActiveSuperAdmin"] = _activeSuperAdmin.GetActiveSuperAdmin();
            var updatedDepartment = _departmentService.GetById(departmentId);
            return View(updatedDepartment);
        }

        [HttpPost]
        public IActionResult UpdateDepartment(Department department)
        {
            _departmentService.Update(department);
            return RedirectToAction("Index", "Department");
        }
    }
}
