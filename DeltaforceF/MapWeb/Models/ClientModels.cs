using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapWeb.Models
{
    public class ClientModels
    {

        // public int idClient { get; set; }
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