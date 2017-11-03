using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness.Entities;
using Bussiness.Logic;
using UI.Web_MVC.Shared;

namespace UI.Web_MVC.Controllers {
    public class InscriptionController : Controller {
        private InscriptionLogic _ctrlInscription = new InscriptionLogic();

        private readonly SubjectLogic _ctrlSubjects = new SubjectLogic();

        private readonly CourseLogic _ctrlCourses = new CourseLogic();

        private Person loggedStudent = (Person)System.Web.HttpContext.Current.Session["person"];  // Reemplazar con usuario logeado

        [NonAction]
        public List<Inscription> GetInscriptionList() {
            return _ctrlInscription.GetAll();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadCourseBySubject(int subjectId) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanReadInscriptions)) {
                return null;
            }

            List<Course> allCoursers = _ctrlCourses.GetAllFreeBySubject(new Subject { Id = subjectId });

            SelectList coursesList = new SelectList(allCoursers, "Id", "Description");

            return Json(coursesList, JsonRequestBehavior.AllowGet);
        }

        // GET: Inscription
        public ActionResult Index() {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.AnyInscription)) {
                return View("403");
            }
            var inscriptions = from e in GetInscriptionList()
                               orderby e.Id
                               select e;
            return View(inscriptions);
        }

        // GET: Inscription/Details/5
        public ActionResult Details(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanReadInscriptions)) {
                return View("403");
            }
            Inscription inscription = GetInscriptionList().Find(e => e.Id == id);
            return View(inscription);
        }

        // GET: Inscription/Create
        public ActionResult Create() {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanCreateInscriptions)) {
                return View("403");
            }
            try {
                ViewBag.AllSubjects = new SelectList(_ctrlSubjects.GetAllByStudent(loggedStudent), "Id", "Description");
                return View();    
            } catch (Exception e) {
                ErrorMessages error = new ErrorMessages();
                return error.ErrorMessage(e.Message, Request);
            }
            
        }

        // POST: Inscription/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanCreateInscriptions)) {
                return View("403");
            }
            try {
                Inscription inscription = new Inscription {
                    Student = loggedStudent.FileNumber,
                    Course = Convert.ToInt32(collection["Course"])
                };

                _ctrlInscription.Create(inscription);

                return RedirectToAction("Index");
            } catch {
                return Create();
            }
        }

        // GET: Inscription/Delete/5
        public ActionResult Delete(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanDeleteInscriptions)) {
                return View("403");
            }
            Inscription inscription = GetInscriptionList().Find(e => e.Id == id);
            return View(inscription);
        }

        // POST: Inscription/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanDeleteInscriptions)) {
                return View("403");
            }
            try {
                _ctrlInscription.Delete(new Inscription { Id = id });

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
