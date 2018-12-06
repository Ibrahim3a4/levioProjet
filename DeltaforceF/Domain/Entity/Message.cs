using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
     public class Message
    {
        public int MessageId { get; set; }

        [Required(ErrorMessage = "You forgot to enter the type of your message!")]
        public MessageType Type { get; set; }

        [Required(ErrorMessage = "You forgot to enter the username of the receiver!")]
        public string Receiver { get; set; }

        [Required(ErrorMessage = "You have to enter the subject!")]
        public string Subject { get; set; }

        [UIHint("MultilineText")]
        [Required(ErrorMessage = "The content of your message is empty!")]
        public string Content { get; set; }

        public DateTime MessageDate { get; set; }

        public bool Received { get; set; }

        public string Sender { get; set; }

        public virtual User MUser { get; set; }

    }
}
