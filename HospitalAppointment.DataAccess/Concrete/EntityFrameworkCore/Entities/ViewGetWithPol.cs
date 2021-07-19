using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.DataAccess.Concrete.EntityFrameworkCore.Entities
{
    [Keyless]
    public partial class ViewGetWithPol
    {
        public int DepId { get; set; }
        [Required]
        [StringLength(50)]
        public string DepartmanName { get; set; }
        public int PolId { get; set; }
        [Required]
        [StringLength(50)]
        public string PoliclinicName { get; set; }
    }


}


