using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Skill
    {

        [Key]
        public int SkillId { get; set; }
        public String SkillName { get; set; }
        public int Level { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }

    }
}
