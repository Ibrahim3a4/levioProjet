using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public  class Resource : User
    {
        public String Seniority { get; set; }
        public String BusinessProfile  { get; set; }
        public int Rating { get; set; }
        public String CV { get; set; }

        public ContractType Contract { get; set; }
        public  AvailabilityState Availability { get; set; }
        public String Photo { get; set; }

        public DateTime HiringDate { get; set; }
        public float Salary { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }

        public virtual ICollection<DayOff> Dayoffs { get; set; }

        public virtual ICollection<Holiday> Holidays  { get; set; }

        public virtual ICollection<Mandate> Mandates { get; set; }
        public int InterMandateId { get; set; }
        [ForeignKey("InterMandateId")]
        public InterMandate InterMandate { get; set; }
    }
}
