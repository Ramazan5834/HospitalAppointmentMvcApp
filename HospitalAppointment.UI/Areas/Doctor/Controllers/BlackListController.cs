using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DTO.DTOs.BlackList;
using HospitalAppointment.UI.StringInfo;
using HospitalAppointment.UI.Tools.ActiveUserContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace HospitalAppointment.UI.Areas.Doctor.Controllers
{
    [Authorize(Roles = RoleInfo.Doctor)]
    [Area(AreaInfo.Doctor)]
    public class BlackListController : Controller
    {
        private ActiveDoctor _activeDoctor;
        private readonly IMapper _mapper;
        private readonly IBlackListService _blackListService;
        private readonly IUserService _userService;
        private readonly IAppointmentService _appointmentService;
        public BlackListController(IAppointmentService appointmentService,IBlackListService blackListService, IMapper mapper, IHttpContextAccessor httpContextAccessor, IUserService userService, IDoctorService doctorService)
        {
            _activeDoctor = new ActiveDoctor(httpContextAccessor, userService, doctorService);
            _mapper = mapper;
            _blackListService = blackListService;
            _userService = userService;
            _appointmentService = appointmentService;
        }
        public bool CreateBlackList(int patientId, int doctorId, DateTime appDateTime)
        {
            var nowAppointment = _appointmentService.GetAppointmentByPatientIdAndDateTime(patientId, appDateTime);
            nowAppointment.Confirmed = true;
            _appointmentService.Update(nowAppointment);
            var addBlackList = new BlackList()
            {
                PatientId = patientId,
                DoctorId = doctorId,
                DeceptionCount = DateTime.Now.AddDays(7),
                Description = _userService.GetById(doctorId).Name + " " + _userService.GetById(doctorId).SurName + "tarafından karaliste oluşturuldu"
            };
            try
            {
                _blackListService.Add(addBlackList);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
