using System;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Entities {
    public class Subject : BussinessEntity {
        [Required]
        public String Description { get; set; }

        [Required]
        public int WeeklyHs { get; set; }

        [Required]
        public int TotalHs { get; set; }

        [Required]
        public int Planid { get; set; }
    }
}
