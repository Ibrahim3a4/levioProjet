using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
   public  class MandateHistory
    {
    	public int IdMandateHistory { get; set; }
        public DateTime SaveDate { get; set; }
        public virtual ICollection <Mandate> Mandates { get; set; }
    }
}