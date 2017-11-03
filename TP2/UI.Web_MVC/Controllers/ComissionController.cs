using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness.Entities;
using Bussiness.Logic;
using UI.Web_MVC.Shared;

namespace UI.Web_MVC.Controllers {
    public class CommissionController : Controller {
        // GET: Commission
        private CommissionLogic _ctrlCommission = new CommissionLogic();

        private readonly CourseLogic _ctrlCourse = new CourseLogic();

        private readonly SpecialtyLogic _ctrlSpecialties = new SpecialtyLogic();

        private readonly PlanLogic _ctrlPlans = new PlanLogic();

        private readonly SubjectLogic _ctrlSubjects = new SubjectLogic();

        private readonly InscriptionLogic _ctrlInscription = new InscriptionLogic();
        

        [NonAction]
        public List<Commission> GetCommissionList() {
            return _ctrlCommission.GetAll();
        }


        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadPlanBySpecialty(int specialtyId) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanReadInscriptions)) {
                return null;
            }

            List<Plan> allPlans = _ctrlPlans.GetAllBySpecialty(new Specialty { Id = specialtyId });

            SelectList coursesList = new SelectList(allPlans, "Id", "Description");

            return Json(coursesList, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadSubjectBySpecialty(int specialtyId)
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanReadInscriptions))
            {
                return null;
            }

            List<Subject> allSubjects = _ctrlSubjects.GetAllByPlan(new Plan { Id = specialtyId });

            SelectList coursesList = new SelectList(allSubjects, "Id", "Description");

            return Json(coursesList, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadComissionBySpecialty(int specialtyId)
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanReadInscriptions))
            {
                return null;
            }

            IEnumerable<Commission> allComissions = _ctrlCommission.GetAllByPlan(new Plan { Id = specialtyId });

            SelectList coursesList = new SelectList(allComissions, "Id", "Description");

            return Json(coursesList, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadActualBySubjectByTeacher(int specialtyId)
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanReadInscriptions))
            {
                return null;
            }

            Person ActiveTeacher = (Person)System.Web.HttpContext.Current.Session["person"];
            List<Course> allCourses = _ctrlCourse.GetActualBySubjectByTeacher(new Subject { Id = specialtyId }, ActiveTeacher);

            SelectList comissionList = new SelectList(allCourses, "Id", "Description");

            return Json(comissionList, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadFilenumberByComission(int specialtyId)
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanReadInscriptions))
            {
                return null;
            }

            List<Inscription> allInscription = _ctrlInscription.GetAllByCourse(new Course { Id = specialtyId });

            SelectList inscriptionList = new SelectList(allInscription, "Student", "Student");

            return Json(inscriptionList, JsonRequestBehavior.AllowGet);
        }


        // GET: Materias
        public ActionResult Index() {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.AnyCommission)) {
                return View("403");
            }
            var commissions = from e in GetCommissionList()
                              orderby e.Id
                              select e;
            return View(commissions);
        }

        // GET: Materias/Details/5
        public ActionResult Details(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanReadCommissions)) {
                return View("403");
            }
            Commission commission = GetCommissionList().Find(e => e.Id == id);
            return View(commission);
        }

        // GET: Materias/Create
        public ActionResult Create() {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanCreateCommissions)) {
                return View("403");
            }
            ViewBag.AllSpecialties = new SelectList(_ctrlSpecialties.GetAll(), "Id", "Description");
            return View();
        }

        // POST: Materias/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanCreateCommissions)) {
                return View("403");
            }
            try {
                Commission commission = new Commission {
                    Description = Convert.ToString(collection["Description"]),
                    YearSpecialty = Convert.ToInt32(collection["YearSpecialty"]),
                    Planid = Convert.ToInt32(collection["Planid"])
                };
                _ctrlCommission.Create(commission);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Materias/Edit/5
        public ActionResult Edit(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanUpdateCommissions)) {
                return View("403");
            }
            Commission commission = GetCommissionList().Find(e => e.Id == id);
            ViewBag.AllSpecialties = new SelectList(_ctrlSpecialties.GetAll(), "Id", "Description");
            return View(commission);
        }

        // POST: Materias/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanUpdateCommissions)) {
                return View("403");
            }
            try {
                Commission commission = new Commission {
                    Id = id,
                    Description = Convert.ToString(collection["Description"]),
                    YearSpecialty = Convert.ToInt32(collection["YearSpecialty"]),
                    Planid = Convert.ToInt32(collection["Planid"])
                };
                _ctrlCommission.Modify(commission);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Materias/Delete/5
        public ActionResult Delete(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanDeleteCommissions)) {
                return View("403");
            }
            Commission commission = GetCommissionList().Find(e => e.Id == id);
            return View(commission);
        }

        // POST: Materias/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanDeleteCommissions)) {
                return View("403");
            }
            try {
                _ctrlCommission.Delete(new Commission { Id = id });

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}