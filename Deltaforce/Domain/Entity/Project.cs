using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Project
    {
        [Key]
        public int Project_id { get; set; }

        public String Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Address { get; set; }
        public ProjectType Type { get; set; }
        public int TotalNbrRessources { get; set; }
        public int TotalNbrLevio { get; set; }
        public String Image { get; set; }
        public virtual ICollection<Mandate> Mandates { get; set; }





    }
}
