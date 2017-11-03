using System.ComponentModel.DataAnnotations;

namespace Bussiness.Entities {
    public class Course : BussinessEntity {
        [Required]
        public int YearCourse { get; set; }

        [Required]
        public int Quota { get; set; }

        [Required]
        public int Commission { get; set; }

        [Required]
        public int Subject { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
