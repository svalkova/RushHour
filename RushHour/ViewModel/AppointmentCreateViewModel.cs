using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RushHour.Models;
using System.Web.Mvc;

namespace RushHour.ViewModel
{
    public class AppointmentCreateViewModel
    {

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int UserId { get; set; }

        public List<Activity> Activities { get; set; }
        public List<SelectListItem> SelectedActivities { get; set; }

        //private List<int> _selectedActivities;
        //public List<int> SelectedActivities
        //{
        //    get
        //    {
        //        if (_selectedActivities == null)
        //        {
        //            _selectedActivities = Appointment.Activities.Select(m => m.Id).ToList();
        //        }
        //        return _selectedActivities;
        //    }
        //    set { _selectedActivities = value; }
        //}
    }
}