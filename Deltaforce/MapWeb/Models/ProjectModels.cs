using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MapWeb.Models
{
    public class ProjectModels
    {
        [Key]
        public int Project_id { get; set; }

        public String Name { get; set; }

        [Column(TypeName = "datetime2")]

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime2")]

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public String Address { get; set; }
        public ProjectType Type { get; set; }
        public int TotalNbrRessources { get; set; }
        public int TotalNbrLevio { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public String Image { get; set; }
      
        public virtual ICollection<Mandate> Mandates { get; set; }


    }
}