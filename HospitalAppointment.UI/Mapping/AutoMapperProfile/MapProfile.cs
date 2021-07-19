using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;
using HospitalAppointment.DTO.DTOs.Appointment;
using HospitalAppointment.DTO.DTOs.BlackList;
using HospitalAppointment.DTO.DTOs.Department;
using HospitalAppointment.DTO.DTOs.Doctor;
using HospitalAppointment.DTO.DTOs.Patient;
using HospitalAppointment.DTO.DTOs.PatientRegistrar;
using HospitalAppointment.DTO.DTOs.Policlinic;
using HospitalAppointment.DTO.DTOs.Prescribe;
using HospitalAppointment.DTO.DTOs.Rol;
using HospitalAppointment.DTO.DTOs.User;

namespace HospitalAppointment.UI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Appointment-AppointmentDto
            CreateMap<Appointment, AppointmentAddDto>();
            CreateMap<AppointmentAddDto, Appointment>();
            CreateMap<Appointment, AppointmentListDto>();
            CreateMap<AppointmentListDto, Appointment>();
            CreateMap<Appointment, AppointmentUpdateDto>();
            CreateMap<AppointmentUpdateDto, Appointment>();
            CreateMap<Appointment, AppointmentsOfPatientRegistrar>();
            CreateMap<AppointmentsOfPatientRegistrar, Appointment>();
            CreateMap<Appointment, AppointmentsOfPatient>();
            CreateMap<AppointmentsOfPatient, Appointment>();
            CreateMap<Appointment, AppointmentsOfDoctorDto>();
            CreateMap<AppointmentsOfDoctorDto, Appointment>();
            #endregion

            #region BlackList-BlackListDto
            CreateMap<BlackList, BlackListAddDto>();
            CreateMap<BlackListAddDto, BlackList>();
            CreateMap<BlackList, BlackListListDto>();
            CreateMap<BlackListListDto, BlackList>();
            CreateMap<BlackList, BlackListUpdateDto>();
            CreateMap<BlackListUpdateDto, BlackList>();
            CreateMap<BlackList, BlackListOfPatientDto>();
            CreateMap<BlackListOfPatientDto, BlackList>();
            #endregion

            #region Department-DepartmentDto
            CreateMap<Department, DepartmentAddDto>();
            CreateMap<DepartmentAddDto, Department>();
            CreateMap<DepartmentListDto, Department>();
            CreateMap<Department, DepartmentListDto>();
            CreateMap<DepartmentUpdateDto, Department>();
            CreateMap<Department, DepartmentUpdateDto>();
            CreateMap<DepPoliclinicAssignDto, Policlinic>();
            CreateMap<Policlinic, DepPoliclinicAssignDto>();
            #endregion

            #region Doctor-DoctorDto
            CreateMap<Doctor, DoctorAddDto>();
            CreateMap<DoctorAddDto, Doctor>();
            CreateMap<User, DoctorListDto>();
            CreateMap<DoctorListDto, User>();
            CreateMap<User, DoctorUpdateDto>();
            CreateMap<DoctorUpdateDto, User>();
            #endregion

            #region Patient-PatientDto
            CreateMap<Patient, PatientAddDto>();
            CreateMap<PatientAddDto, Patient>();
            CreateMap<User, PatientListDto>();
            CreateMap<PatientListDto, User>();
            CreateMap<User, PatientUpdateDto>();
            CreateMap<PatientUpdateDto, User>();
            #endregion

            #region PatientRegistrar-PatientRegistrarDto
            CreateMap<PatientRegistrar, PatientRegistrarAddDto>();
            CreateMap<PatientRegistrarAddDto, PatientRegistrar>();
            CreateMap<User, PatientRegistrarListDto>();
            CreateMap<PatientRegistrarListDto, User>();
            CreateMap<User, PatientRegistrarUpdateDto>();
            CreateMap<PatientRegistrarUpdateDto, User>();
            #endregion

            #region Policlinic-PoliclinicDto
            CreateMap<Policlinic, PoliclinicAddDto>();
            CreateMap<PoliclinicAddDto, Policlinic>();
            CreateMap<Policlinic, PoliclinicListDto>();
            CreateMap<PoliclinicListDto, Policlinic>();
            CreateMap<Policlinic, PoliclinicUpdateDto>();
            CreateMap<PoliclinicUpdateDto, Policlinic>();
            CreateMap<Policlinic, PoliclinicOfDepartmentDto>();
            CreateMap<PoliclinicOfDepartmentDto, Policlinic>();
            #endregion

            #region Prescribe-PrescribeDto
            CreateMap<Prescribe, PrescribeAddDto>();
            CreateMap<PrescribeAddDto, Prescribe>();
            CreateMap<Prescribe, PrescribeListDto>();
            CreateMap<PrescribeListDto, Prescribe>();
            CreateMap<Prescribe, PrescribeUpdateDto>();
            CreateMap<PrescribeUpdateDto, Prescribe>();
            CreateMap<Prescribe, PrescribeOfPatientDto>();
            CreateMap<PrescribeOfPatientDto, Prescribe>();
            #endregion

            #region Rol-RolDto
            CreateMap<Rol, RolAddDto>();
            CreateMap<RolAddDto, Rol>();
            CreateMap<Rol, RolListDto>();
            CreateMap<RolListDto, Rol>();
            CreateMap<Rol, RolUpdateDto>();
            CreateMap<RolUpdateDto, Rol>();
            #endregion

            #region SuperAdmin-SuperAdminDto

            #endregion

            #region User-UserDto
            CreateMap<User, UserAddDto>();
            CreateMap<UserAddDto, User>();
            CreateMap<User, UserListDto>();
            CreateMap<UserListDto, User>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
            #endregion

        }
    }
}
