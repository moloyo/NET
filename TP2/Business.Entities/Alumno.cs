using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Alumno
    {
        public String Name { get; set; }
        public int Legajo { get; set; }
        public String Address { get; set; }
        public String Email { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EntranceYear { get; set; }
    }
}
