using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ResRequest
    {
        [Key]
        public int resreqId { get; set; }
        public RessourceType ressourceType { get; set; }
        public int yearsOfExperience { get; set; }
        public String diploma { get; set; }
        public DateTime depositDate { get; set; }
        public DateTime treatedDate { get; set; }
        public DateTime startDateWork { get; set; }
        public DateTime endDateWork { get; set; }
        public float cost { get; set; }
        public virtual ICollection<Skill> skillz { get; set; }
        public int? ProjectIdFK { get; set; }
        [ForeignKey("ProjectIdFK")]
        public Project projet { get; set; }
        public String ClientIdFK { get; set; }
        [ForeignKey("ClientIdFK")]
        public Client Client { get; set; }
        public String ResourceIdFK { get; set; }
        [ForeignKey("ResourceIdFK")]
        public Resource Resource { get; set; }
        public bool treated { get; set; }

    }
}
