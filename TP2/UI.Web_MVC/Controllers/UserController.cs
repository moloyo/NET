using Bussiness.Entities;
using Bussiness.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Web_MVC.Shared;

namespace UI.Web_MVC.Controllers {
    public class UserController : Controller {
        private readonly UserLogic _ctrlUser = new UserLogic();

        private List<User> UserList;

        public UserController() {
            UserList = _ctrlUser.GetAll();
        }
        // GET: User
        public ActionResult Index() {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.AnyUser)) {
                return View("403");
            }
            var users = from e in UserList
                        orderby e.Id
                        select e;
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanReadUsers)) {
                return View("403");
            }
            return View();
        }

        // GET: User/Create
        public ActionResult Create() {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanCreateUsers)) {
                return View("403");
            }
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanCreateUsers)) {
                return View("403");
            }
            try {

                User user = new User {
                    Username = Convert.ToString(collection["Username"]),
                    Password = Util.Util.Sha1HashString(Convert.ToString(collection["Password"])),
                    Person = Convert.ToInt32(collection["Person"]),
                };

                _ctrlUser.Create(user);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanUpdateUsers)) {
                return View("403");
            }
            User user = UserList.Find(e => e.Id == id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanUpdateUsers)) {
                return View("403");
            }
            try {
                User user = new User {
                    Id = id,
                    Username = Convert.ToString(collection["Username"]),
                    Password = Util.Util.Sha1HashString(Convert.ToString(collection["Password"])),
                    Person = Convert.ToInt32(collection["Person"]),
                };

                _ctrlUser.Modify(user);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanDeleteUsers)) {
                return View("403");
            }
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            if (!AccessManager.ActiveUserHasPermissions(Privileges.CanDeleteUsers)) {
                return View("403");
            }
            try {
                User user = new User {
                    Id = id,
                    Username = Convert.ToString(collection["Username"]),
                };

                _ctrlUser.Delete(user);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
