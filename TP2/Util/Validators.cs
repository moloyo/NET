using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bussiness.Entities;

namespace Util {
    public class Validators {

        public static bool isValidEmail(string email) {
            return Regex.IsMatch(email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
        }

        public static bool UserHasPermission(User user, Privileges privilege) {
            return user.PrivilegesList.Contains(privilege);
        }

    }
}
