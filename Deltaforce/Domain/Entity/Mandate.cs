using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        public int IdMandateHistory { get; set; }
        [ForeignKey("IdMandateHistory")]
        public MandateHistory MandateHistory { get; set; }
        public int IdResource { get; set; }
        [ForeignKey("IdResource")]
        public Resource Resource { get; set; }
        public int IdProject { get; set; }
        [ForeignKey("IdProject")]
        public Project Project { get; set; }
    }
}