using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RushHour.Models
{
    public class Appointment : BaseEntity
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}