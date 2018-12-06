using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Models
{
    public class ResourceModel : User
    {

        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String Gender { get; set; }

        public String Seniority { get; set; }
        public String BusinessProfile { get; set; }
        public int Rating { get; set; }
        public String CV { get; set; }


        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }
        public float Salary { get; set; }

        public virtual InterMandate InterMandate { get; set; }

        [ForeignKey("InterMandateId")]
        public int? InterMandateId { get; set; }



        public String PhoneNumber { get; set; }

        public String UserName { get; set; }
        public String Email { get; set; }

        public String Photo { get; set; }
        public Boolean TwoFactorEnabled { get; set; }

        [Required(ErrorMessage = "La date est obligatoire")]
        [DataType(DataType.Date)]
        public DateTime? LockoutEndDateUtc { get; set; }

        //public IEnumerable<SelectListItem> Intermandates { get; set; }



    }

}