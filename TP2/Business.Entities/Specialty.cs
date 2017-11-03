using System;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Entities {
    public class Specialty : BussinessEntity {
        [Required]
        public String Description { get; set; }
    }
}
