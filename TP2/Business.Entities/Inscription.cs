using System.ComponentModel.DataAnnotations;

namespace Bussiness.Entities {
    public class Inscription : BussinessEntity {

        [Required]
        public int Student { get; set; }

        [Required]
        public int Course { get; set; }

        public Condition Condition { get; set; }

        public double Qualification { get; set; }
    }

    public enum Condition {
        Pass = 0,
        Attending = 1,
        NotPassed = 2
    }
}
