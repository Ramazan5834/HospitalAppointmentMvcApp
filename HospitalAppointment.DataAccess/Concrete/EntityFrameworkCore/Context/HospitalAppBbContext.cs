using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities;

#nullable disable

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public partial class HospitalAppBbContext : DbContext
    {
        public HospitalAppBbContext()
        {
        }

        public HospitalAppBbContext(DbContextOptions<HospitalAppBbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<BlackList> BlackLists { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientRegistrar> PatientRegistrars { get; set; }
        public virtual DbSet<Policlinic> Policlinics { get; set; }
        public virtual DbSet<Prescribe> Prescribes { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<SuperAdmin> SuperAdmins { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ViewGetWithPol> ViewGetWithPols { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HospitalAppDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => new { e.Date, e.DoctorId });

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Appointment_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Appointment_Patient");

                entity.HasOne(d => d.Registrar)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.RegistrarId)
                    .HasConstraintName("FK_Appointment_PatientRegistrar");
            });

            modelBuilder.Entity<BlackList>(entity =>
            {
                entity.Property(e => e.DoctorId).HasDefaultValueSql("((-1))");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.BlackLists)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlackList_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.BlackLists)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_BlackList_Patient");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Doctor_Department");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Doctor)
                    .HasForeignKey<Doctor>(d => d.Id)
                    .HasConstraintName("FK_Doctor_User1");

                entity.HasOne(d => d.SuperAdmin)
                    .WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SuperAdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doctor_SuperAdmin");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Patient)
                    .HasForeignKey<Patient>(d => d.Id)
                    .HasConstraintName("FK_Patient_User1");

                entity.HasOne(d => d.SuperAdmin)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.SuperAdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Patient_SuperAdmin");
            });

            modelBuilder.Entity<PatientRegistrar>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PatientRegistrar)
                    .HasForeignKey<PatientRegistrar>(d => d.Id)
                    .HasConstraintName("FK_PatientRegistrar_User1");

                entity.HasOne(d => d.SuperAdmin)
                    .WithMany(p => p.PatientRegistrars)
                    .HasForeignKey(d => d.SuperAdminId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PatientRegistrar_SuperAdmin");
            });

            modelBuilder.Entity<Policlinic>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Policlinics)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Policlinic_Department");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Policlinic)
                    .HasForeignKey<Policlinic>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Policlinic_Doctor");
            });

            modelBuilder.Entity<Prescribe>(entity =>
            {
                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescribes)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prescribe_Doctor");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Prescribes)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_Prescribe_Patient");
            });

            modelBuilder.Entity<SuperAdmin>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.SuperAdmin)
                    .HasForeignKey<SuperAdmin>(d => d.Id)
                    .HasConstraintName("FK_SuperAdmin_User1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Rol");
            });

            modelBuilder.Entity<ViewGetWithPol>(entity =>
            {
                entity.ToView("View_GetWithPol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
