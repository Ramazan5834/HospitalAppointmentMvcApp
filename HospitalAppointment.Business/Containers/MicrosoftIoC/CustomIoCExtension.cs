using System;
using System.Collections.Generic;
using System.Text;
using HospitalAppointment.Business.Concrete;
using HospitalAppointment.Business.Interfaces;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Context;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using HospitalAppointment.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalAppointment.Business.Containers.MicrosoftIoC
{
    public static class CustomIoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<HospitalAppBbContext>();

            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));

            services.AddScoped<IAppointmentService, AppointmentManager>();
            services.AddScoped<IAppointmentDal, EfAppointmentRepository>();

            services.AddScoped<IBlackListService, BlackListManager>();
            services.AddScoped<IBlackListDal, EfBlackListRepository>();

            services.AddScoped<IDepartmentService, DepartmentManager>();
            services.AddScoped<IDepartmentDal, EfDepartmentRepository>();

            services.AddScoped<IDoctorService, DoctorManager>();
            services.AddScoped<IDoctorDal, EfDoctorRepository>();

            services.AddScoped<IPatientRegistrarService, PatientRegistrarManager>();
            services.AddScoped<IPatientRegistrarDal, EfPatientRegistrarRepository>();

            services.AddScoped<IPatientService, PatientManager>();
            services.AddScoped<IPatientDal, EfPatientRepository>();

            services.AddScoped<IPoliclinicService, PoliclinicManager>();
            services.AddScoped<IPoliclinicDal, EfPoliclinicRepository>();

            services.AddScoped<IPrescribeService, PrescribeManager>();
            services.AddScoped<IPrescribeDal, EfPrescribeRepository>();

            services.AddScoped<IRolService, RolManager>();
            services.AddScoped<IRolDal, EfRolRepository>();

            services.AddScoped<ISuperAdminService, SuperAdminManager>();
            services.AddScoped<ISuperAdminDal, EfSuperAdminRepository>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, EfUserRepository>();

        }
    }
}
