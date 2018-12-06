using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MapWeb.Models
{
    public class ProjectModel
    {
        [Key]
        public int Project_id { get; set; }

        public String Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Address { get; set; }
        public ProjectTypeModel Type { get; set; }
        public int TotalNbrRessources { get; set; }
        public int TotalNbrLevio { get; set; }
        public String Image { get; set; }
        public virtual ICollection<MandateModel> Mandates { get; set; }
    }
}