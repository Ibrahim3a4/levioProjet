using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MapWeb.Models
{
    public class InterMandateModel
    {
        [Key]
        public int InterMandateId { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string IdResource { get; set; }
        [ForeignKey("IdResource")]
        public ResourceModel Resource { get; set; }
    } 
}