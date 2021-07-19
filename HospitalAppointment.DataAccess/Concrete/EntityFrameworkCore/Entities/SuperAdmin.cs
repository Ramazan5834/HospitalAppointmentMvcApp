using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities
{
    [Table("SuperAdmin")]
    public partial class SuperAdmin
    {
        public SuperAdmin()
        {
            Doctors = new HashSet<Doctor>();
            PatientRegistrars = new HashSet<PatientRegistrar>();
            Patients = new HashSet<Patient>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellation { get; set; }

        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(User.SuperAdmin))]
        public virtual User IdNavigation { get; set; }
        [InverseProperty(nameof(Doctor.SuperAdmin))]
        public virtual ICollection<Doctor> Doctors { get; set; }
        [InverseProperty(nameof(PatientRegistrar.SuperAdmin))]
        public virtual ICollection<PatientRegistrar> PatientRegistrars { get; set; }
        [InverseProperty(nameof(Patient.SuperAdmin))]
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
