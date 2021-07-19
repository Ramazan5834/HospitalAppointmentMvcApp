using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities
{
    [Table("Department")]
    public partial class Department
    {
        public Department()
        {
            Doctors = new HashSet<Doctor>();
            Policlinics = new HashSet<Policlinic>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string DepartmanName { get; set; }

        [InverseProperty(nameof(Doctor.Department))]
        public virtual ICollection<Doctor> Doctors { get; set; }
        [InverseProperty(nameof(Policlinic.Department))]
        public virtual ICollection<Policlinic> Policlinics { get; set; }
    }
}
