using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities
{
    [Table("BlackList")]
    public partial class BlackList
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "smalldatetime")]
        public DateTime DeceptionCount { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [ForeignKey(nameof(DoctorId))]
        [InverseProperty("BlackLists")]
        public virtual Doctor Doctor { get; set; }
        [ForeignKey(nameof(PatientId))]
        [InverseProperty("BlackLists")]
        public virtual Patient Patient { get; set; }
    }
}
