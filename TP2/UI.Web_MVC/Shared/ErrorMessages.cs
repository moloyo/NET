using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace UI.Web_MVC.Shared {
    public class ErrorMessages : Controller {

        public ActionResult ErrorMessage(HttpRequestBase Request)
        {
            return ErrorMessage("Unexpected error", Request);
        }

        public ActionResult ErrorMessage(string message, HttpRequestBase Request)
        {
            System.Web.HttpContext.Current.Session["message"] = message;
            if (Request.UrlReferrer != null) {
                return Redirect(Request.UrlReferrer.ToString());
            }
            return RedirectToAction("Index", "Home");
        }
    }
}