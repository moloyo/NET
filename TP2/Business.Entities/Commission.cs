using System;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Entities {
    public class Commission : BussinessEntity {
        [Required]
        public int YearSpecialty { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Planid { get; set; }
    }
}
