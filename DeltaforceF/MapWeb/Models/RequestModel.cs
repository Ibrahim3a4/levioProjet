using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MapWeb.Models
{
    public class RequestModel
    {
        [Key]
        public int idRequest { get; set; }
        public String requirements { get; set; }
        public String profileRequired { get; set; }
        public String career { get; set; }
        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        public DateTime startDate { get; set; }
        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        public DateTime endDate { get; set; }
        public String director { get; set; }
        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        public DateTime depositDate { get; set; }
    }
}