using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Request
    {   [Key]
        public int idRequest { get; set; }
        public String requirements{ get; set; }
        public String profileRequired { get; set; }
        public String career { get; set; }
        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }
        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        public DateTime endDate { get; set; }
        
        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        public DateTime depositDate { get; set; }




    }
}
