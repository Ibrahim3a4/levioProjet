using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Domain.Entity
{

    public class Project
    {
        [Key]
        public int Project_id { get; set; }

        public String Name { get; set; }

        [Column(TypeName = "datetime2")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime2")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "EndDate")]
        [DateGreaterThan("StartDate")]
        public DateTime EndDate { get; set; }
        public String Address { get; set; }
        public ProjectType Type { get; set; }
        public int TotalNbrRessources { get; set; }
        public int TotalNbrLevio { get; set; }
        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string Image { get; set; }
        public virtual ICollection<Mandate> Mandates { get; set; }
    





    }
}
