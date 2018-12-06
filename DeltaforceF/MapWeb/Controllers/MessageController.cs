using Data;
using Microsoft.AspNet.Identity;
using Domain.Entity;
using MapWeb.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Service.Identity;
using System.Web.Security;
using System.Net.Mail;
using System.Web.Routing;
using System.Data.Entity;

namespace MapWeb.Controllers
{
    public class MessageController : Controller
    {
        private ApplicationUserManager _userManager;

        ServiceMessage sm = new ServiceMessage();
        ServiceClient sc = new ServiceClient();
        LevioMapCtx db = new LevioMapCtx();

        public String GetCurrentUserId()
        {
            var currlog = HttpContext.User.Identity.GetUserId();
            ViewBag.UserId = currlog;
            return currlog;
        }
        public String GetCurrentUserName()
        {
            string currName = HttpContext.GetOwinContext()
                               .GetUserManager<ApplicationUserManager>()
                              .FindById(HttpContext.User.Identity.GetUserId()).FirstName;
            ViewBag.UserFirstName = currName;
            return currName;
        }
        public String GetCurrentUserMail()
        {
            var currMail = HttpContext.User.Identity.GetUserName();
            ViewBag.UserEmail = currMail;
            return currMail;
        }

        public ActionResult Test()
        {
            /**************************/
            string curUserName = HttpContext.GetOwinContext()
                         .GetUserManager<ApplicationUserManager>()
                        .FindById(HttpContext.User.Identity.GetUserId()).FirstName;
            var msgs = from m in db.Message
                       where m.Receiver == curUserName
                       select m;

            int nbrMsgs = msgs.Count();
            ViewBag.UserRecMsg = nbrMsgs;
            /******************************/
            var req = db.Message;
            return View(req);
        }
        // GET: Message
        public ActionResult Index()
        {

            var currlog = HttpContext.User.Identity.GetUserId();
            var currNam = HttpContext.User.Identity.GetUserName();
            string curUserName = HttpContext.GetOwinContext()
                               .GetUserManager<ApplicationUserManager>()
                              .FindById(HttpContext.User.Identity.GetUserId()).FirstName;
            ViewBag.UserId = currlog;
            ViewBag.UserFirstName = curUserName;
            ViewBag.UserName = currNam;

            var req = sm.GetMany();

            return View(req);
        }
        // GET: ReceivedMessages
        public ActionResult ReceivedMsg()
        {
            string curUserName = HttpContext.GetOwinContext()
                              .GetUserManager<ApplicationUserManager>()
                             .FindById(HttpContext.User.Identity.GetUserId()).FirstName;

            var req = sm.GetReceivedMessages(curUserName);
            return View(req);
        }
        public ActionResult SentMsg()
        {
            var currId = HttpContext.User.Identity.GetUserId();
            var req = sm.GetSentMessages(currId);

            return View(req);
        }
        // GET: Message/Edit/5
        public ActionResult MyDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message sms = db.Message.Find(id);
            sms.Received = true;
            db.Entry(sms).State = EntityState.Modified;
            db.SaveChanges();
            sm.Commit();
            if (sms == null)
            {
                return HttpNotFound();
            }
            return View(sms);
        }

        // GET: Message/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message sms = db.Message.Find(id);

            string senderMsg = HttpContext.GetOwinContext()
                 .GetUserManager<ApplicationUserManager>()
                .FindById(sms.Sender).FirstName;
            /*********/
            sms.Received = true;
            db.Entry(sms).State = EntityState.Modified;
            db.SaveChanges();
            sm.Commit();
            /****************/
            string sendM = sms.Sender.ToString();
            ViewBag.MessagTypEnum = sms.Type.ToString();
            ViewBag.MsgSender = senderMsg;
            var req = from m in db.Users
                      where m.UserName == sms.Sender
                      select m.Email;
            ViewBag.Em = req.ToString();
            if (sms == null)
            {
                return HttpNotFound();
            }

            return View(sms);
        }


        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Message/Create
        [HttpPost]
        public ActionResult Create(Message msg)
        {
            try
            {

                Message mm = new Message
            {
                Type = msg.Type,
                Receiver = msg.Receiver,
                Subject = msg.Subject,
                Content = msg.Content,
                MessageDate = DateTime.Now,
                Received = msg.Received,
                //Sender = GetCurrentUserId()
                Sender= GetCurrentUserName()

                };
                sm.Add(mm);
                sm.Commit();
                return RedirectToAction("ReceivedMsg");
            }
            catch
            {
                return View();
            }
        }

        // GET: Message/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Message/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resource/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists please contact Levio's system administrator.";
            }
            Message msg = db.Message.Find(id);
            ViewBag.MessagTypEnum = msg.Type.ToString();

            string senderMsg = HttpContext.GetOwinContext()
                              .GetUserManager<ApplicationUserManager>()
                             .FindById(msg.Sender).FirstName;

            ViewBag.MsgSender = senderMsg;
            if (msg == null)
            {
                return HttpNotFound();
            }
            return View(msg);
        }

        // POST: Resource/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Message msg = db.Message.Find(id);
                db.Message.Remove(msg);
                db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("ReceivedMsg");
        }
    }
}
