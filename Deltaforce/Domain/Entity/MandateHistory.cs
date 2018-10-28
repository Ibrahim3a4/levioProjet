using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
   public  class MandateHistory
    {
        [Key]
    	public int IdMandateHistory { get; set; }
        public DateTime SaveDate { get; set; }
        public virtual ICollection <Mandate> Mandates { get; set; }
    }
}