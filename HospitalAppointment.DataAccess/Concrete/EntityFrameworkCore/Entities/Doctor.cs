using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities
{
    [Table("Doctor")]
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
            BlackLists = new HashSet<BlackList>();
            Prescribes = new HashSet<Prescribe>();
        }

        [Key]
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellation { get; set; }
        public int SuperAdminId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Doctors")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(User.Doctor))]
        public virtual User IdNavigation { get; set; }
        [ForeignKey(nameof(SuperAdminId))]
        [InverseProperty("Doctors")]
        public virtual SuperAdmin SuperAdmin { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual Policlinic Policlinic { get; set; }
        [InverseProperty(nameof(Appointment.Doctor))]
        public virtual ICollection<Appointment> Appointments { get; set; }
        [InverseProperty(nameof(BlackList.Doctor))]
        public virtual ICollection<BlackList> BlackLists { get; set; }
        [InverseProperty(nameof(Prescribe.Doctor))]
        public virtual ICollection<Prescribe> Prescribes { get; set; }
    }
}
