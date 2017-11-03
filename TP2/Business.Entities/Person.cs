using System;
using System.ComponentModel.DataAnnotations;

namespace Bussiness.Entities {
    public class Person : BussinessEntity {

        [Required]
        public String Name { get; set; }

        [Required]
        public String LastName { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String BirthDate { get; set; }

        [Required]
        public int FileNumber { get; set; }

        [Required]
        public String PhoneNumber { get; set; }

        [Required]
        public String Address { get; set; }


        public int? Planid { get; set; }

        [Required]
        public int TypePerson { get; set; }
    }

    public enum PersonTypes {
        Student = 0,
        Teacher = 1,
        NonTeacher = 2
    }
}
