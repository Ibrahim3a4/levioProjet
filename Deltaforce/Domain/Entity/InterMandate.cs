using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
   public  class InterMandate
    {
        [Key]
        public int InterMandateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public virtual ICollection <Resource> Resources { get; set; }


    }
}
