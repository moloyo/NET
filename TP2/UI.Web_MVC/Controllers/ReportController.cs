using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Windows.Controls;
using Bussiness.Logic;
using Bussiness.Entities;
using Microsoft.Reporting.WebForms;
using UI.Web_MVC.Shared;
using UI.Web_MVC.Models;

namespace UI.Web_MVC.Controllers
{
    public class ReportController : Controller
    {
        private readonly SpecialtyLogic _ctrlSpecialties = new SpecialtyLogic();

        private Person ActiveTeacher;

        // GET: Report
        #region AttendingList
        public ActionResult AttendingList()
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.AnyPerson))
            {
                return View("403");
            }
            ActiveTeacher = (Person)System.Web.HttpContext.Current.Session["person"];
            ViewBag.AllSpecialties = new SelectList(_ctrlSpecialties.GetByTeacher(ActiveTeacher), "Id", "Description");
            return View();
        }

        [HttpPost]
        public ActionResult AttendingList(FormCollection collection)
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.AnyPerson))
            {
                return View("403");
            }
            try
            {
                ActiveTeacher = (Person)System.Web.HttpContext.Current.Session["person"];
                System.Web.HttpContext.Current.Session["AttendingListModel"] =
                    new AttendingListModel() {Course = int.Parse(collection["comissionList"]), Filenumber = ActiveTeacher.FileNumber};
            }
            catch (Exception e)
            {
                ErrorMessages error = new ErrorMessages();
                return error.ErrorMessage(e.Message, Request);
            }
            return RedirectToAction("Listado", "Report");
        }

        public ActionResult Listado()
        {
            AttendingListModel atm = (AttendingListModel)System.Web.HttpContext.Current.Session["AttendingListModel"];
            DataTable dataReport = ReportLogic.AttendingList(atm.Filenumber, atm.Course);
            return View(ConvertToIEnumerable(dataReport));
        }

        private IEnumerable<AlumnosListadoModel> ConvertToIEnumerable(DataTable dataTable)
        {
            var attEnum = new List<AlumnosListadoModel>();
            foreach (DataRow row in dataTable.Rows)
            {
                var tankReading = new AlumnosListadoModel()
                {
                    Filenumber = Convert.ToInt32(row["Filenumber"]),
                    Name = Convert.ToString(row["Name"]),
                    Lastname = Convert.ToString(row["Lastname"])
                };
                attEnum.Add(tankReading);
            }
            return attEnum.AsEnumerable();
        }
        #endregion

        #region AverageStudent
        public ActionResult StudentAverage()
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.AnyPerson))
            {
                return View("403");
            }
            ActiveTeacher = (Person)System.Web.HttpContext.Current.Session["person"];
            ViewBag.AllSpecialties = new SelectList(_ctrlSpecialties.GetByTeacher(ActiveTeacher), "Id", "Description");
            return View();
        }

        [HttpPost]
        public ActionResult StudentAverage(FormCollection collection)
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.AnyPerson))
            {
                return View("403");
            }
            try
            {
                System.Web.HttpContext.Current.Session["FilenumberAverage"] = int.Parse(collection["Filenumber"]);
            }
            catch (Exception e)
            {
                ErrorMessages error = new ErrorMessages();
                return error.ErrorMessage(e.Message, Request);
            }
            return RedirectToAction("ListadoAverage", "Report");
        }

        public ActionResult ListadoAverage()
        {
            int filenumberAverage = Convert.ToInt32(System.Web.HttpContext.Current.Session["FilenumberAverage"]);
            int promedio = ReportLogic.StudentAverage(filenumberAverage);
            AlumnoAverage alumno = new AlumnoAverage() {Promedio = promedio};
            return View(alumno);
        }

        #endregion

        #region BestStudents

        public ActionResult BestStudentByYear()
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.AnyPerson))
            {
                return View("403");
            }
            return View();
        }

        [HttpPost]
        public ActionResult BestStudentByYear(FormCollection collection)
        {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.AnyPerson))
            {
                return View("403");
            }
            try
            {
                System.Web.HttpContext.Current.Session["BestStudentModel"] =
                    new BestStudentByYearModel() { Year = int.Parse(collection["Year"]) };
            }
            catch (Exception e)
            {
                ErrorMessages error = new ErrorMessages();
                return error.ErrorMessage(e.Message, Request);
            }
            return RedirectToAction("ListadoBestStudent", "Report");
        }

        public ActionResult ListadoBestStudent()
        {
            var bsym = (BestStudentByYearModel)System.Web.HttpContext.Current.Session["BestStudentModel"];
            var dataReport = ReportLogic.BestStudentByYear(bsym.Year);
            return View(ConvertStudents(dataReport));
        }

        private IEnumerable<BestStudentModel> ConvertStudents(DataTable dataTable)
        {
            var attEnum = (from DataRow row in dataTable.Rows
                select new BestStudentModel()
                {
                    Filenumber = Convert.ToInt32(row["Filenumber"]),
                    Name = Convert.ToString(row["Name"]),
                    Lastname = Convert.ToString(row["Lastname"]),
                    Average = Convert.ToInt32(row["Average"])
                }).ToList();
            return attEnum.AsEnumerable();
        }

        #endregion


    }
}