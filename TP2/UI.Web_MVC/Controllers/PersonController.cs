using Bussiness.Entities;
using Bussiness.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web_MVC.Shared;

namespace UI.Web_MVC.Controllers {
    public class PersonController : Controller {
        private readonly PersonLogic _ctrlPerson = new PersonLogic();

        private List<Person> PersonList;

        public PersonController() {
            PersonList = _ctrlPerson.GetAll();

            Dictionary<int, String> PersonTypesList = new Dictionary<int, string>();

            foreach (PersonTypes foo in Enum.GetValues(typeof(PersonTypes))) {
                PersonTypesList.Add((int)foo, foo.ToString());
            }

            ViewBag.PersonTypesDropDown = new SelectList(PersonTypesList, "Key", "Value");
        }

        // GET: Person
        public ActionResult Index() {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.AnyPerson)) {
                return View("403");
            }
            var persons = from e in PersonList
                          orderby e.Id
                          select e;
            return View(persons);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanReadPersons)) {
                return View("403");
            }
            Person person = PersonList.Find(e => e.Id == id);
            return View(person);
        }

        // GET: Person/Create
        public ActionResult Create() {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanCreatePersons)) {
                return View("403");
            }
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanCreatePersons)) {
                return View("403");
            }
            try {
                Person person = new Person {
                    Name = Convert.ToString(collection["Name"]),
                    LastName = Convert.ToString(collection["LastName"]),
                    Email = Convert.ToString(collection["Email"]),
                    Address = Convert.ToString(collection["Address"]),
                    PhoneNumber = Convert.ToString(collection["PhoneNumber"]),
                    FileNumber = Convert.ToInt32(collection["FileNumber"]),
                    BirthDate = Convert.ToString(collection["BirthDate"]),
                    TypePerson = Convert.ToInt32(collection["TypePerson"])
                };

                _ctrlPerson.Create(person);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanUpdatePersons)) {
                return View("403");
            }
            Person person = PersonList.Find(e => e.Id == id);
            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanUpdatePersons)) {
                return View("403");
            }
            try {
                Person person = new Person {
                    Id = id,
                    Name = Convert.ToString(collection["Name"]),
                    LastName = Convert.ToString(collection["LastName"]),
                    Email = Convert.ToString(collection["Email"]),
                    Address = Convert.ToString(collection["Address"]),
                    PhoneNumber = Convert.ToString(collection["PhoneNumber"]),
                    FileNumber = Convert.ToInt32(collection["FileNumber"]),
                    BirthDate = Convert.ToString(collection["BirthDate"]),
                    TypePerson = Convert.ToInt32(collection["TypePerson"])
                };
                _ctrlPerson.Modify(person);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanDeletePersons)) {
                return View("403");
            }
            Person person = PersonList.Find(e => e.Id == id);
            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanDeletePersons)) {
                return View("403");
            }
            try {
                _ctrlPerson.Delete(new Person {
                    Id = id,
                    FileNumber = Convert.ToInt32(collection["FileNumber"])
                });

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
