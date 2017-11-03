using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Web_MVC.Controllers {
    public class LogOutController : Controller {
        // GET: LogOut
        public ActionResult Index() {
            System.Web.HttpContext.Current.Session["user"] = null;
            System.Web.HttpContext.Current.Session["person"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}