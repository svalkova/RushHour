using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RushHour.DataAccess;
using RushHour.Models;

namespace RushHour.Controllers
{
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult ActivityList()
        {
            ActivityRepository activityRepository = new ActivityRepository();
            List<Activity> activities = activityRepository.GetAll();
            return View(activities);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Activity activity)
        {

            if (ModelState.IsValid)
            {
                ActivityRepository repository = new ActivityRepository();
                repository.Insert(activity);

                return RedirectToAction("ActivityList");
            }
            else
            {
                return View(activity);
            }
        }
        public ActionResult Delete(int? id)
        {
            ActivityRepository repository = new ActivityRepository();
            Activity activity = repository.GetById(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ActivityRepository repository = new ActivityRepository();
            Activity activity = repository.GetById(id);
            repository.Delete(activity);
            return RedirectToAction("ActivityList");
        }



        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ActivityRepository repository = new ActivityRepository();
            Activity activity = repository.GetById(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Activity activity)
        {
            if (ModelState.IsValid)
            {
                ActivityRepository repository = new ActivityRepository();
                repository.Update(activity);
                return RedirectToAction("ActivityList");
            }
            return View(activity);
        }

        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ActivityRepository repository = new ActivityRepository();
            Activity activity = repository.GetById(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }
    }
}