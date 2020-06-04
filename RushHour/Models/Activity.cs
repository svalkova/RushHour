using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RushHour.Models
{
    public class Activity : BaseEntity
    {
        public string Name { get; set; }
        public float Duration { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}