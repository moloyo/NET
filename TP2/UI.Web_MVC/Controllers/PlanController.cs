using Bussiness.Entities;
using Bussiness.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web_MVC.Shared;

namespace UI.Web_MVC.Controllers {
    public class PlanController : Controller {
        private readonly PlanLogic _ctrlPlan = new PlanLogic();

        private readonly SpecialtyLogic _ctrlSpecialties = new Bussiness.Logic.SpecialtyLogic();

        private List<Plan> PlanList;

        public PlanController() {
            ViewBag.AllSpecialties = new SelectList(_ctrlSpecialties.GetAll(), "Id", "Description");
            PlanList = _ctrlPlan.GetAll();
        }

        // GET: Plan
        public ActionResult Index() {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.AnyPlan)) {
                return View("403");
            }
            var plans = from e in PlanList
                        orderby e.Id
                        select e;
            return View(plans);
        }

        // GET: Plan/Details/5
        public ActionResult Details(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanReadPlans)) {
                return View("403");
            }
            Plan plan = PlanList.Find(e => e.Id == id);
            return View(plan);
        }

        // GET: Plan/Create
        public ActionResult Create() {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanCreatePlans)) {
                return View("403");
            }
            return View();
        }

        // POST: Plan/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanCreatePlans)) {
                return View("403");
            }
            try {
                Plan plan = new Plan {
                    Description = Convert.ToString(collection["Description"]),
                    Specialty = int.Parse(Convert.ToString(collection["Specialty"]))
                };

                _ctrlPlan.Create(plan);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Plan/Edit/5
        public ActionResult Edit(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanUpdatePlans)) {
                return View("403");
            }
            Plan plan = PlanList.Find(e => e.Id == id);
            return View(plan);
        }

        // POST: Plan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanUpdatePlans)) {
                return View("403");
            }
            try {
                Plan plan = new Plan {
                    Id = id,
                    Description = Convert.ToString(collection["Description"]),
                    Specialty = int.Parse(Convert.ToString(collection["Specialty"]))
                };
                _ctrlPlan.Modify(plan);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Plan/Delete/5
        public ActionResult Delete(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanDeletePlans)) {
                return View("403");
            }
            Plan plan = PlanList.Find(e => e.Id == id);
            return View(plan);
        }

        // POST: Plan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanDeletePlans)) {
                return View("403");
            }
            try {
                _ctrlPlan.Delete(new Plan { Id = id });

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
