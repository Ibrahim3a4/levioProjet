using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    class Project
    {
        [Key]
        public int project_id { get; set; }
        public String name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public String address { get; set; }
        public ProjectType type { get; set; }
        public int totalNbrRessources { get; set; }
        public int totalNbrLevio { get; set; }
        public String image { get; set; }
        public Client c { get; set; }

        


    }
}
