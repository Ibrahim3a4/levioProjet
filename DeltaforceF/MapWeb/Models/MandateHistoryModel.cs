using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MapWeb.Models
{
    public class MandateHistoryModel
    {
        [Key]
        public int IdMandateHistory { get; set; }
        public DateTime SaveDate { get; set; }
        public virtual ICollection<MandateModel> Mandates { get; set; }
    }
}