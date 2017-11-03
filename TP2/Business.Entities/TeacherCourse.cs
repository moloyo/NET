using System.ComponentModel.DataAnnotations;

namespace Bussiness.Entities {
    public class TeacherCourse : BussinessEntity {

        [Required]
        public int Position { get; set; }

        [Required]
        public int Course { get; set; }

        [Required]
        public int Teacher { get; set; }
    }

    public enum Positions {
        Jefe = 0,
        JefeDeTp = 1,
        Auxiliar = 2
    }
}
