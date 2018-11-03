using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapWeb.Models
{
    public class ResourceModel
    {
        public String Seniority { get; set; }
        public String BusinessProfile { get; set; }
        public int Rating { get; set; }
        public String CV { get; set; }

        public String Photo { get; set; }

        public DateTime HiringDate { get; set; }
        public float Salary { get; set; }
    }
}