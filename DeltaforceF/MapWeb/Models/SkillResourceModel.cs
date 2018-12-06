using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Models 
{
    public class SkillResourceModel : Skill
    {
        [Key, Column(Order = 1)]
        public int SkillIdFK { get; set; }
        [ForeignKey("SkillIdFK")]
        public Skill Skill { get; set; }

        [Key, Column(Order = 2)]
        public String ResourceIdFK { get; set; }
        [ForeignKey("ResourceIdFK")]
        public Resource Resource { get; set; }


        public int Level { get; set; }

        public IEnumerable<SelectListItem> Skills { get; set; }
        public IEnumerable<SelectListItem> Resources { get; set; }
    }
}