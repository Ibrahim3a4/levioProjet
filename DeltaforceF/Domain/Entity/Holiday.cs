using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Holiday
    {
        public int HolidayId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime History { get; set; }


        public virtual ICollection<Resource> Resources { get; set; }
    }
}
