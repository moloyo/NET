using Bussiness.Entities;
using Bussiness.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web_MVC.Shared;

namespace UI.Web_MVC.Controllers {
    public class SpecialtyController : Controller {
        private SpecialtyLogic _ctrlSpecialty = new SpecialtyLogic();

        [NonAction]
        public List<Specialty> GetSpecialtyList() {
            return _ctrlSpecialty.GetAll();
        }

        // GET: Specialty
        public ActionResult Index() {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.AnySpecialty)) {
                return View("403");
            }
            var specialties = from e in GetSpecialtyList()
                              orderby e.Id
                              select e;
            return View(specialties);
        }

        // GET: Specialty/Details/5
        public ActionResult Details(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanReadSpecialties)) {
                return View("403");
            }
            Specialty specialty = GetSpecialtyList().Find(e => e.Id == id);
            return View(specialty);
        }

        // GET: Specialty/Create
        public ActionResult Create() {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanCreateSpecialties)) {
                return View("403");
            }
            return View();
        }

        // POST: Specialty/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanCreateSpecialties)) {
                return View("403");
            }
            try {
                Specialty specialty = new Specialty {
                    Description = Convert.ToString(collection["Description"])
                };

                _ctrlSpecialty.Create(specialty);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Specialty/Edit/5
        public ActionResult Edit(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanUpdateSpecialties)) {
                return View("403");
            }
            Specialty specialty = GetSpecialtyList().Find(e => e.Id == id);
            return View(specialty);
        }

        // POST: Specialty/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanUpdateSpecialties)) {
                return View("403");
            }
            try {
                Specialty specialty = new Specialty {
                    Id = id,
                    Description = Convert.ToString(collection["Description"])
                };
                _ctrlSpecialty.Modify(specialty);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Specialty/Delete/5
        public ActionResult Delete(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanDeleteSpecialties)) {
                return View("403");
            }
            Specialty specialty = GetSpecialtyList().Find(e => e.Id == id);
            return View(specialty);
        }

        // POST: Specialty/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanDeleteSpecialties)) {
                return View("403");
            }
            try {
                _ctrlSpecialty.Delete(new Specialty { Id = id });

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
