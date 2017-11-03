using Bussiness.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness.Entities;
using UI.Web_MVC.Shared;

namespace UI.Web_MVC.Controllers
{
    public class QualificationsController : Controller
    {
        private readonly InscriptionLogic _ctrlInscription = new InscriptionLogic();

        private readonly SpecialtyLogic _ctrlSpecialties = new SpecialtyLogic();

        // GET: Qualifications
        [HttpGet]
        public ActionResult Index()
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.AnyPerson))
            {
                return View("403");
            }
            Person ActiveTeacher = (Person)System.Web.HttpContext.Current.Session["person"];
            ViewBag.AllSpecialties = new SelectList(_ctrlSpecialties.GetByTeacher(ActiveTeacher), "Id", "Description");
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            if (!AccessManager.AuthenticatedUser())
            {
                return RedirectToAction("Index", "Home");
            }
            try
            {
                double qualification = double.Parse(collection["Qualification"].ToString());
                Bussiness.Entities.Condition condition;

                if (qualification < 6)
                {
                    condition = Bussiness.Entities.Condition.NotPassed;
                }
                else if (qualification > 8)
                {
                    condition = Bussiness.Entities.Condition.Pass;
                }
                else
                {
                    condition = Bussiness.Entities.Condition.Attending;
                }

                Inscription inscription = new Inscription
                {
                    Qualification = qualification,
                    Condition = condition,
                    Student = int.Parse(collection["filenumberList"]),
                    Course = int.Parse(collection["comissionList"])
                };

                _ctrlInscription.UpdateQualification(inscription);
                return RedirectToAction("Index", "Qualifications");
            }
            catch (Exception e )
            {
                ErrorMessages error = new ErrorMessages();
                return error.ErrorMessage(e.Message, Request);
            }
        }
    }
}