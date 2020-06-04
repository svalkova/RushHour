using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RushHour.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool isAdmin { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}