using Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MapWeb.Models
{
    public class MessageModel
    {
       // public List<MessageType> Types { get; set; }
        public MessageType Type { get; set; }

        [Required(ErrorMessage = "You forgot to enter the username of the receiver!")]
        public string Receiver { get; set; }

        [Required(ErrorMessage = "You have to enter the subject!")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "The content of your message is empty!")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public DateTime MessageDate { get; set; }
        public bool Received { get; set; }
        public string Sender { get; set; }
        public MessageModel() { }
        public MessageModel(MessageType typ, string rec, string sub, string cont, DateTime dat, bool recu, string us)
        {
            typ = MessageType.complaint;
            rec = Receiver;
            sub = Subject;
            cont = Content;
            dat = DateTime.Now;
            recu = false;
            us = Sender;  //currentUser
        }

    }
}