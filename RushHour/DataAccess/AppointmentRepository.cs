using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RushHour.Models;
using System.Linq.Expressions;

namespace RushHour.DataAccess
{
    public class AppointmentRepository : Repository<Appointment>
    {
        public List<Activity> Activities(Expression<Func<Activity,bool>> filter)
        {
            ActivityRepository repository = new ActivityRepository(context);
            List<Activity> activities = repository.GetAll(filter);
            return activities;
        }
    }
}