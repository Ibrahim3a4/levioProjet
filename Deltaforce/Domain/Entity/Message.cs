using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
     public class Message
    {
        public int MessageId { get; set; }
        public MessageType Type { get; set; }
        public DateTime MessageDate{ get; set; }
        public string Content { get; set; }
        public string Subject { get; set; }
        public bool Received { get; set; }
        //public int SenderId { get; set; }
        //[ForeignKey("SenderId")]
        //public User User { get; set; }
        public string Sender{ get; set; }
        public string Receiver { get; set; }
    
    }
}
