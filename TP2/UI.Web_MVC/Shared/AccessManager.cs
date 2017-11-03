using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bussiness.Entities;
using Util;

namespace UI.Web_MVC.Shared {
    public class AccessManager {
        public static bool ActiveUserHasPermissions(Privileges privilege) {
            if (!AuthenticatedUser()) {
                return false;
            }
            return Validators.UserHasPermission((User)System.Web.HttpContext.Current.Session["user"], privilege);
        }

        public static bool AuthenticatedUser() {
            return (User)System.Web.HttpContext.Current.Session["user"] != null;
        }
    }
}