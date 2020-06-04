using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RushHour.Models;
using RushHour.DataAccess;

namespace RushHour.Controllers
{
    public class UserController : Controller
    {
        public static int UserId { get; set; }
        // GET: User
        public ActionResult AdminView()
        {
            UserRepository repository = new UserRepository();
            List<User> users = repository.GetAll();
            return View(users);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                UserRepository repository = new UserRepository();
                repository.Insert(user);
                return RedirectToAction("LogIn");
            }
            else
            {
                return View(user);
            }

        }

        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(User user)
        {
            bool flag = false;
                UserRepository userRepo = new UserRepository();
                List<User> users = userRepo.GetAll();
                foreach(User us in users)
                {
                    if (us!=null)
                    {
                        if (user.Email == us.Email && user.Password == us.Password)
                        {
                             UserId = us.Id;
                            if (us.isAdmin)
                            {
                                return RedirectToAction("AdminView");
                            
                            }
                            else
                            {
                                return RedirectToAction("AppointmentList", "Appointment");
                            }
                        }
                        else
                        {
                            flag = true;
                        }

                    }   
                }

            if (flag == true)
            {
                return RedirectToAction("LogIn");
            }

            return RedirectToAction("AppointmentList");
           

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                UserRepository repository = new UserRepository();
                repository.Insert(user);
                return RedirectToAction("AdminView");
            }
            else
            {
                return View(user);
            }

        }

        public ActionResult Delete(int? id)
        {
            UserRepository repository = new UserRepository();
            User user = repository.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserRepository repository = new UserRepository();
            User user = repository.GetById(id);
            repository.Delete(user);
            return RedirectToAction("AdminView");
        }



        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            UserRepository repository = new UserRepository();
            User user = repository.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                UserRepository repository = new UserRepository();
                repository.Update(user);
                return RedirectToAction("AdminView");
            }
            return View(user);
        }

        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            UserRepository repository = new UserRepository();
            User user = repository.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }



    }
}