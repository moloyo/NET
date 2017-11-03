using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace Bussiness.Entities {
    public class User : BussinessEntity {

        public string Name { get; set; }

        public string LastName { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 6, ErrorMessage = "field must be atleast 6 characters")]
        public string Password { get; set; }

        public string EMail { get; set; }

        public bool Enable { get; set; }

        [Required]
        public string Username { get; set; }

        public int Person { get; set; }

        public List<Privileges> PrivilegesList { get; set; }

        private long _privileges;
        public long Privileges {
            get { return _privileges; }
            set {
                PrivilegesList = Permissions.FromIntToPrivileges(value);
                _privileges = value;
            }
        }
    }
}