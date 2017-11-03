using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness.Entities;
using Bussiness.Logic;
using UI.Web_MVC.Shared;

namespace UI.Web_MVC.Controllers {
    public class LogInController : Controller {
        private UserLogic ctrUser = new UserLogic();

        private PersonLogic ctrPerson = new PersonLogic();

        // GET: LogIn
        [HttpGet]
        public ActionResult Index() {
            if (AccessManager.AuthenticatedUser()) {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password) {
            if (AccessManager.AuthenticatedUser()) {
                return RedirectToAction("Index", "Home");
            }
            try {
                User user = new User() { Username = username, Password = Util.Util.Sha1HashString(password) };
                User loggeduser = ctrUser.LogIn(user);
                System.Web.HttpContext.Current.Session["user"] = loggeduser;
                System.Web.HttpContext.Current.Session["person"] = ctrPerson.GetByUser(loggeduser);
                return RedirectToAction("Index", "Home");
            } catch (Exception) {
                ErrorMessages error = new ErrorMessages();
                return error.ErrorMessage("Datos Incorrectos", Request);
            }
        }

    }
}