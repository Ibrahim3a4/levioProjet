using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public enum RessourceType
    {
        Employee,
        Freelancer
    }
    public  class Resource : User
    {
        
        public String Seniority { get; set; }
        public String BusinessProfile  { get; set; }
        public int Rating { get; set; }
        public String CV { get; set; }

        public RessourceType Type { get; set; }

        public ContractType Contract { get; set; }
        public  AvailabilityState Availability { get; set; }
        public String Photo { get; set; }

        [Column(TypeName = "datetime2")]

        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }
        public float Salary { get; set; }

        public virtual ICollection<SkillResource> SkillResource { get; set; }

        public virtual ICollection<DayOff> Dayoffs { get; set; }

        public virtual ICollection<Holiday> Holidays  { get; set; }

        public virtual ICollection<Mandate> Mandates { get; set; }
        public int? InterMandateId { get; set; }
        [ForeignKey("InterMandateId")]
         public InterMandate InterMandate { get; set; }
    }
}
