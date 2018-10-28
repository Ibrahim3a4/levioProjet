using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class DayOff
    {
        public int DayoffId { get; set; }
        public DateTime DDate { get; set; }

        public String Reason { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
