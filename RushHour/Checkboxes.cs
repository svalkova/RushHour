using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RushHour.Models;

namespace RushHour
{
    public class Checkboxes
    {
        public bool Checked { get; set; }
        public string Text { get; set; }
        public User LogedUser { get; set; }
    }
}