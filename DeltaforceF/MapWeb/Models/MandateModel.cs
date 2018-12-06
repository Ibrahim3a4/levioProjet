using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Models
{
    public class MandateModel
    {
        public int MandateId { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public int? Fees { get; set; }

        public int IdMandateHistory { get; set; }
        [ForeignKey("IdMandateHistory")]
        public MandateHistoryModel MandateHistory { get; set; }
        public string Disponibility { get; set; }
        [Key]
        [Column(Order = 1)]
        public string IdResource { get; set; }
        [ForeignKey("IdResource")]
        public ResourceModel Resource { get; set; }
        [Key]
        [Column(Order = 2)]
        public int IdProject { get; set; }
        [ForeignKey("IdProject")]
        public ProjectModel Project { get; set; }

        public IEnumerable<SelectListItem> Resources { get; set; }
        public IEnumerable<SelectListItem> Projects { get; set; }
    }
}