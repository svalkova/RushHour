using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RushHour.DataAccess;
using RushHour.Models;
using RushHour.ViewModel;


namespace RushHour.Controllers
{
    public class AppointmentController : Controller
    {
        float time = 0;
        // GET: Appointment
        public ActionResult AppointmentList()
        {
            AppointmentRepository appointmentRepository = new AppointmentRepository();
            List<Appointment> appointments = appointmentRepository.GetAll(app => app.UserId == UserController.UserId);
            return View(appointments);
        }
        public ActionResult Create()
        {
            ActivityRepository repository = new ActivityRepository();
            AppointmentCreateViewModel appointmentViewModel = new AppointmentCreateViewModel();
            appointmentViewModel.StartDateTime = DateTime.Now;
            appointmentViewModel.EndDateTime = DateTime.Now;

            List<Activity> activities = repository.GetAll();
            appointmentViewModel.SelectedActivities = new List<SelectListItem>();
            foreach (var activity in activities)
            {
                appointmentViewModel.SelectedActivities.Add(new SelectListItem
                {
                    Text = activity.Name,
                    Value = activity.Id.ToString(),
                    Selected = false
                });
            }
            //appointmentViewModel.Activities = repository.GetAll();

            return View(appointmentViewModel);
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "SelectedActivities")]AppointmentCreateViewModel model, string[] selectedActivities)
        {
            //if (ModelState.IsValid)
            {
                AppointmentRepository repository = new AppointmentRepository();
                Appointment appointment = new Appointment();
                appointment.UserId = UserController.UserId;
                appointment.StartDateTime = model.StartDateTime;



                appointment.Activities = GetSelectedActivities(selectedActivities,repository);

                foreach (var item in appointment.Activities)
                {
                    time += item.Duration;
                }
                appointment.EndDateTime = model.StartDateTime.AddHours(time);
                repository.Insert(appointment);

                return RedirectToAction("AppointmentList");
            }
            //else
            //{
            //    return View(model);
            //}\\
        }

        private List<Activity> GetSelectedActivities(string[] selectedActivities, AppointmentRepository repository)
        {
            List<Activity> result = new List<Activity>();
            result.AddRange(repository.Activities(a => selectedActivities.Any(s => a.Id.ToString() == s)));

            return result;
        }

        public ActionResult Delete(int? id)
        {
            AppointmentRepository repository = new AppointmentRepository();
            Appointment appointment = repository.GetById(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }
        [HttpPost, ActionName("Delete")] 
        public ActionResult DeleteConfirmed(int id)
        {
            AppointmentRepository repository = new AppointmentRepository();
            Appointment appointment = repository.GetById(id);
            repository.Delete(appointment);
            return RedirectToAction("AppointmentList");
        }



        public ActionResult Edit(int? id)
        {
            
            AppointmentRepository repository = new AppointmentRepository();
            Appointment appointment = repository.GetById(id);
            AppointmentCreateViewModel model = new AppointmentCreateViewModel();
            model.UserId = appointment.UserId;
            model.StartDateTime = appointment.StartDateTime;

            ActivityRepository activityRepo = new ActivityRepository();
            List<Activity> act = activityRepo.GetAll();
            int counter = -1;
            model.SelectedActivities = new List<SelectListItem>();
            foreach (var activity in act)
            {
                counter++;
                model.SelectedActivities.Add(new SelectListItem
                {
                    Text = activity.Name,
                    Value = activity.Id.ToString(),
                    Selected = false
                });

                foreach (var item in appointment.Activities)
                {
                    if (activity.Id == item.Id)
                    {
                        model.SelectedActivities[counter].Selected = true;
                        break;
                    }
                }
            }

            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Appointment appointment, string [] selectedActivities)
        {
            if (ModelState.IsValid)
            {
                AppointmentRepository repository = new AppointmentRepository();
                Appointment app = repository.GetById(appointment.Id);
                app.Activities.Clear(); 
                app.Activities = GetSelectedActivities(selectedActivities, repository);
                foreach (var item in app.Activities)
                {
                    time += item.Duration;
                }
                app.UserId = UserController.UserId;
                app.EndDateTime = app.StartDateTime.AddHours(time);
                repository.Update(app);
                return RedirectToAction("AppointmentList");
            }
            return View(appointment);

        }

        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            AppointmentRepository repository = new AppointmentRepository();
            Appointment appointment = repository.GetById(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);

        }
    }
}