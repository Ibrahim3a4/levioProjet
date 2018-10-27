using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class DayOff
    {
        public DateTime DayoffId { get; set; }
        public DateTime StartDate { get; set; }

        public String Reason { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
