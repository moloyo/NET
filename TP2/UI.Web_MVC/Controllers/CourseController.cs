using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bussiness.Logic;
using Bussiness.Entities;
using UI.Web_MVC.Shared;

namespace UI.Web_MVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly CommissionLogic _ctrlCommission = new CommissionLogic();

        private readonly CourseLogic _ctrlCourse = new CourseLogic();

        private readonly SubjectLogic _ctrlSubject = new SubjectLogic();

        private readonly SpecialtyLogic _ctrlSpecialties = new SpecialtyLogic();

        [NonAction]
        public List<Course> GetCourseList()
        {
            return _ctrlCourse.GetAll();
        }

        // GET: Course
        public ActionResult Index()
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.AnyCommission))
            {
                return View("403");
            }
            var course = from e in GetCourseList()
                orderby e.Id
                select e;
            return View(course);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanReadCommissions))
            {
                return View("403");
            }
            Course course = GetCourseList().Find(c => c.Id == id);
            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanCreateCommissions))
            {
                return View("403");
            }
            ViewBag.AllSpecialties = new SelectList(_ctrlSpecialties.GetAll(), "Id", "Description");
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanCreateCommissions))
            {
                return View("403");
            }
            try
            {
                Course course = new Course
                {
                    YearCourse = Convert.ToInt32(collection["YearCourse"]),
                    Commission = Convert.ToInt32(collection["comissionList"]),
                    Subject = Convert.ToInt32(collection["subjectList"]),
                    Quota = Convert.ToInt32(collection["Quota"])
                };
                _ctrlCourse.Create(course);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanUpdateCommissions))
            {
                return View("403");
            }
            Course course = GetCourseList().Find(e => e.Id == id);
            ViewBag.AllSpecialties = new SelectList(_ctrlSpecialties.GetAll(), "Id", "Description");
            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanUpdateCommissions))
            {
                return View("403");
            }
            try
            {
                Course course = new Course
                {
                    Id = id,
                    YearCourse = Convert.ToInt32(collection["YearCourse"]),
                    Commission = Convert.ToInt32(collection["comissionList"]),
                    Subject = Convert.ToInt32(collection["subjectList"]),
                    Quota = Convert.ToInt32(collection["Quota"])
                };
                _ctrlCourse.Modify(course);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanUpdateCommissions))
            {
                return View("403");
            }
            Course course = GetCourseList().Find(e => e.Id == id);
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanDeleteCommissions))
            {
                return View("403");
            }
            try
            {
                _ctrlCourse.Delete(new Course { Id = id });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
