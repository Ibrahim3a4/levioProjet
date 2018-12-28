using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
System.Web.Http.Owin;
using Microsoft.AspNet.Identity;
using System.Net.Http;
using Data;
using Service;
using Domain.Entity;
using MapWeb.Models;
using Service.Identity;

using System.Net;

using System.Web.Security;
using System.Net.Mail;
using System.Web.Routing;
using System.Data.Entity;

namespace MapWeb.Controllers
{
    public class APIMessageController : ApiController
    {
        private ApplicationUserManager _userManager;

        ServiceMessage sm = new ServiceMessage();
        ServiceClient sc = new ServiceClient();
        LevioMapCtx db = new LevioMapCtx();

        public String GetCurrentUserName()
        {
            string currName = HttpContext.GetOwinContext()
                               .GetUserManager<ApplicationUserManager>()
                              .FindById(HttpContext.User.Identity.GetUserId()).FirstName;

            return currName;
        }

        [Route("api/messageList")]
        [HttpGet]
        public IHttpActionResult Index()
        {
            List<MessageModel> msl = new List<Models.MessageModel>();
            foreach (var item in sm.GetMany())
            {
                MessageModel mm = new MessageModel();
                mm.Subject = item.Subject;
                msl.Add(mm);
            }
            return Ok(msl);
        }

        /**************************/
        [Route("api/messagerecList")]
        [HttpGet]
        public IHttpActionResult ReceivedMsg()
        {
            string curUserName = HttpContext.GetOwinContext()
                              .GetUserManager<ApplicationUserManager>()
                             .FindById(HttpContext.User.Identity.GetUserId()).FirstName;

            List<MessageModel> msl = new List<Models.MessageModel>();
            foreach (var item in sm.GetReceivedMessages(curUserName))
            {
                MessageModel mm = new MessageModel();
                mm.Subject = item.Subject;
                msl.Add(mm);
            }
            return Ok(msl);
        }
        /**************************/

        [Route("api/messagedetails/{id}")]
        [HttpGet]
        public IHttpActionResult Details(int id)
        {
            Message msg = sm.GetById(id);
            return Ok(msg);
            
        }

        [Route("api/messageadd")]
        [HttpPost]
        public IHttpActionResult Create(MessageModel msg)
        {

            Message c = new Message {
                Type = msg.Type,
                 Receiver = msg.Receiver,
                 Subject = msg.Subject,
                 Content = msg.Content,
                 MessageDate = DateTime.Now,
                 Received=msg.Received,
                 Sender=GetCurrentUserName()
             };
            sm.Add(c);
            sm.Commit();
            return Ok();
        }

        [Route("api/messagedel/{id}")]
        [HttpPost]
        public IHttpActionResult Delete(int id, MessageModel msg)
        {

            var req = sm.GetMany().Where(a => a.MessageId == id).FirstOrDefault();
            sm.Delete(req);
            sm.Commit();
            return Ok();
        }
    }
}
