using RushHour.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RushHour.DataAccess
{
    public class ActivityRepository : Repository<Activity>
    {
        public ActivityRepository():base ()
        {

        }
        public ActivityRepository(RushHourContext contex):base(contex)
        {

        }
    }
}