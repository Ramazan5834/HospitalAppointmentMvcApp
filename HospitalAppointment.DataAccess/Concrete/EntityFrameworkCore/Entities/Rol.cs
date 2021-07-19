using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities
{
    [Table("Rol")]
    public partial class Rol
    {
        public Rol()
        {
            Users = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string RolName { get; set; }

        [InverseProperty(nameof(User.Rol))]
        public virtual ICollection<User> Users { get; set; }
    }
}
