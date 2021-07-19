using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities
{
    [Table("User")]
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [Column("TCNo")]
        public long Tcno { get; set; }
        public int RolId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string SurName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime BirthDate { get; set; }
        public long Telephone { get; set; }
        public bool Gender { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [ForeignKey(nameof(RolId))]
        [InverseProperty("Users")]
        public virtual Rol Rol { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual Doctor Doctor { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual Patient Patient { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual PatientRegistrar PatientRegistrar { get; set; }
        [InverseProperty("IdNavigation")]
        public virtual SuperAdmin SuperAdmin { get; set; }
    }
}
