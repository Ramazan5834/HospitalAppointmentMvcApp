using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities
{
    [Table("Prescribe")]
    public partial class Prescribe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string DiseaseName { get; set; }
        [Required]
        [StringLength(50)]
        public string Medicine { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [ForeignKey(nameof(DoctorId))]
        [InverseProperty("Prescribes")]
        public virtual Doctor Doctor { get; set; }
        [ForeignKey(nameof(PatientId))]
        [InverseProperty("Prescribes")]
        public virtual Patient Patient { get; set; }
    }
}
