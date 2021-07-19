using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities
{
    [Table("Appointment")]
    public partial class Appointment
    {
        [Key]
        [Column(TypeName = "smalldatetime")]
        public DateTime Date { get; set; }
        public int? RegistrarId { get; set; }
        [Key]
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public bool Confirmed { get; set; }
        public DateTime CreatingDate { get; set; }

        [ForeignKey(nameof(DoctorId))]
        [InverseProperty("Appointments")]
        public virtual Doctor Doctor { get; set; }
        [ForeignKey(nameof(PatientId))]
        [InverseProperty("Appointments")]
        public virtual Patient Patient { get; set; }
        [ForeignKey(nameof(RegistrarId))]
        [InverseProperty(nameof(PatientRegistrar.Appointments))]
        public virtual PatientRegistrar Registrar { get; set; }
    }
}
