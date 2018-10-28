using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
     public class Mandate
    {
        public int MandateId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Fees { get; set; }
        public int? IdMandateHistory { get; set; }
        public virtual ICollection <Resource> Resources { get; set; }
        public int Project_Id { get; set; }
    }
}