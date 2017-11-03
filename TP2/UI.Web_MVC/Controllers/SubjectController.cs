using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness.Logic;
using Bussiness.Entities;
using UI.Web_MVC.Shared;
using Util;

namespace UI.Web_MVC.Controllers {
    public class SubjectController : Controller {
        private SubjectLogic _ctrlSubject = new SubjectLogic();

        [NonAction]
        public List<Subject> GetSubjectList() {
            return _ctrlSubject.GetAll();
        }
        // GET: Materias
        public ActionResult Index() {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.AnySubject)) {
                return View("403");
            }

            var subjects = from e in GetSubjectList()
                           orderby e.Id
                           select e;
            return View(subjects);
        }

        // GET: Materias/Details/5
        public ActionResult Details(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanReadSubjects)) {
                return View("403");
            }
            Subject subject = GetSubjectList().Find(e => e.Id == id);
            return View(subject);
        }

        // GET: Materias/Create
        public ActionResult Create() {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanCreateSubjects)) {
                return View("403");
            }
            return View();
        }

        // POST: Materias/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanCreateSubjects)) {
                return View("403");
            }
            try {
                Subject subject = new Subject {
                    Description = Convert.ToString(collection["Description"]),
                    WeeklyHs = Convert.ToInt32(collection["WeeklyHs"]),
                    //TotalHs = Convert.ToInt32(collection["TotalHs"]),
                    Planid = Convert.ToInt32(collection["Planid"])
                };
                _ctrlSubject.Create(subject);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Materias/Edit/5
        public ActionResult Edit(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanUpdateSubjects)) {
                return View("403");
            }
            Subject subject = GetSubjectList().Find(e => e.Id == id);
            return View(subject);
        }

        // POST: Materias/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanUpdateSubjects)) {
                return View("403");
            }
            try {
                Subject subject = new Subject {
                    Id = id,
                    Description = Convert.ToString(collection["Description"]),
                    WeeklyHs = Convert.ToInt32(collection["WeeklyHs"]),
                    TotalHs = Convert.ToInt32(collection["TotalHs"]),
                    Planid = Convert.ToInt32(collection["Planid"])
                };
                _ctrlSubject.Modify(subject);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Materias/Delete/5
        public ActionResult Delete(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanDeleteSubjects)) {
                return View("403");
            }
            Subject subject = GetSubjectList().Find(e => e.Id == id);
            return View(subject);
        }

        // POST: Materias/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanDeleteSubjects)) {
                return View("403");
            }
            try {
                _ctrlSubject.Delete(new Subject { Id = id });

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
