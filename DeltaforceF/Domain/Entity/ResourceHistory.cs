using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class ResourceHistory
    {

        [Key]
        public int ResourceHistoryId { get; set; }

        public String LastName { get; set; }

        public String FirstName { get; set; }

        public String Username { get; set; }

    }
}
