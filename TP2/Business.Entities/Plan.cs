using System;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Entities {
    public class Plan : BussinessEntity {
        [Required]
        public String Description { get; set; }

        [Required]
        public int Specialty { get; set; }

    }
}
