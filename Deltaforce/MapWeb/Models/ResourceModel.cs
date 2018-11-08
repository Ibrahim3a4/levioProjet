using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MapWeb.Models
{
    public class ResourceModel
    {

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Gender { get; set; }

        public String Seniority { get; set; }
        public String BusinessProfile { get; set; }
        public int Rating { get; set; }
        public String CV { get; set; }


        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }
        public float Salary { get; set; }



    }
    
}