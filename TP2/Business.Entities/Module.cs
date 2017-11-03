using System;
using System.Collections.Generic;

namespace Bussiness.Entities {
    public class Module : BussinessEntity {
        public String Name { get; set; }

        public String Description { get; set; }

        public List<Privileges> Privileges { get; set; }
    }
}
