using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities
{
    [Table("Policlinic")]
    public partial class Policlinic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string PoliclinicName { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Policlinics")]
        public virtual Department Department { get; set; }
        [ForeignKey(nameof(Id))]
        [InverseProperty(nameof(Doctor.Policlinic))]
        public virtual Doctor IdNavigation { get; set; }
    }
}
