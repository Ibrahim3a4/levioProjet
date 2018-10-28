using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
   public class Client : User
    {

        public ClientCategory Category { get; set; }
        public ClientType Type { get; set; }
        public String Logo { get; set; }
        public String Addresse { get; set; }

        public String OrganizationalChart { get; set; }

        public int NbResInServ { get; set; }
        public int NbProjAf { get; set; }
        public virtual ICollection<Project> Projects { get; set; }

    }
}
