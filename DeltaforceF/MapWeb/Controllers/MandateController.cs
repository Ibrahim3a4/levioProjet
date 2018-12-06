using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MapWeb.Models;
using Service;
using Domain.Entity;
using Data;
using Microsoft.CSharp.RuntimeBinder;
using System.Reflection;
using System.Web.UI;

using System.Net.Mail;
using System.Web.Helpers;
using System.Web.UI.WebControls;


namespace MapWeb.Controllers
{
    public class MandateController : Controller
    {
        private MapWebContext db = new MapWebContext();
        private ServiceMandate s = new ServiceMandate();
        private ServiceResourceSabrine si = new ServiceResourceSabrine();
        private ServiceProjectSabrine sii = new ServiceProjectSabrine();
        private ServiceResource srs = new ServiceResource();

        List<MandateModel> mandateModels;
        IEnumerable<Mandate> mandates;



        public int? CalculFees(MandateModel md, string idRessource)
        {
            Resource rs = si.GetMany().Where(r => r.Id.Equals(idRessource)).FirstOrDefault();

            //DateTime date1 = md.StartDate;
            //DateTime date2 = md.EndDate;
            //int nbrMonth1 = date1.Month;
            //int nbrYear1 = date1.Year;
            //int nbrMonth2 = date2.Month;
            //int nbrYear2 = date2.Year;
            //int Duree = ((nbrMonth2 - nbrMonth1) * 30) + ((nbrYear2 - nbrYear1) * 365);
            var Duree = (int)(md.EndDate - md.StartDate).TotalDays;
            return Duree * ((int)rs.Salary);
        }

        public MandateController()
        {
            mandateModels = new List<MandateModel>();
            mandates = s.GetMandates();
            foreach (var m in mandates)
            {
                var req = from p in si.GetMany()
                          where p.Id == m.IdResource
                          select p;
                var r = req.FirstOrDefault();
                ResourceModel rm = new ResourceModel() { FirstName = r.FirstName, LastName = r.LastName, Salary = (int)r.Salary };


                var reqe = from p in sii.GetMany()
                           where p.Project_id == m.IdProject
                           select p;
                var re = reqe.FirstOrDefault();
                ProjectModel pm = new ProjectModel() { Name = re.Name };


                MandateModel md = new MandateModel() { MandateId = m.MandateId, EndDate = m.EndDate, Fees = m.Fees, IdProject = m.IdProject, IdResource = m.IdResource, StartDate = m.StartDate, Resource = rm, Project = pm, Disponibility = m.Disponibility };
                mandateModels.Add(md);

                if (md.StartDate >= System.DateTime.Today)
                {
                    md.Disponibility = "available";
                }

                else
                {
                    md.Disponibility = "unavailable";
                }

            }
        }








        // GET: Mandate
        public ActionResult Index()
        {
            return View(mandateModels.ToList());
        }


        // GET: Mandate/Details/5
        public ActionResult Details(int id)
        {
            var mandate = mandateModels.Find(e => e.MandateId == id);
            //            MandateModel md = new MandateModel() { EndDate = m.EndDate, Fees = m.Fees, IdProject = m.IdProject, IdResource = m.IdResource, MandateId = m.MandateId, StartDate = m.StartDate };

            return View(mandate);
        }


        // GET: Mandate/Create
        public ActionResult Create()
        {
            // ViewBag.IdMandateHistory = new SelectList(db.MandateHistoryModels, "IdMandateHistory", "IdMandateHistory");

            MandateModel re = new MandateModel();
            re.Resources = srs.GetMany().Select(c => new SelectListItem
            {
                Text = c.UserName,
                Value = c.Id,
            });


            re.Projects = sii.GetMany().Select(cc => new SelectListItem
            {
                Text = cc.Name,
                Value = cc.Project_id.ToString(),
            });

            return View(re);
        }

        // POST: Mandate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdResource,IdProject,MandateId,StartDate,EndDate,Fees")] MandateModel mandateModel)
        {


            if (ModelState.IsValid)
            {

                Mandate m = new Mandate() { MandateId = mandateModel.MandateId, IdMandateHistory = 1, EndDate = mandateModel.EndDate, Fees = CalculFees(mandateModel, mandateModel.IdResource), IdProject = mandateModel.IdProject, IdResource = mandateModel.IdResource, StartDate = mandateModel.StartDate, Disponibility = mandateModel.Disponibility };
                s.AddMandate(m);
                //db.MandateModels.Add(mandateModel);
                s.Commit();


                //MailMessage mail = new MailMessage("sabrine.gmati25@gmail.com", "bassemzouari.1994@gmail.com");
                //SmtpClient client = new SmtpClient();
                //client.Credentials = new NetworkCredential("sabrine.gmati25@gmail.com", "Espritsabrine100");
                //client.Port = 25;
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.UseDefaultCredentials = false;
                //client.Host = "smtp.gmail.com";
                //mail.Subject = "this is a test email.";
                //mail.Body = "this is my test email body";
                //client.Send(mail);
                var req = from p in si.GetMany()
                          where p.Id == mandateModel.IdResource
                          select p;
                var r = req.FirstOrDefault();


                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("sabrine.gmati25@gmail.com");
                mail.To.Add(r.Email);
                mail.Subject = "Assignment to a mandate";
                mail.IsBodyHtml = true;
                mail.Body = "<div style='width:80%;margin-left:10%;border:1.5px solid #1b1a19;border-radius:7px;background:-moz-linear-gradient(top,white 0%,white 55%,#d5e4f3 130%)'>" +
    "<img src = 'https://scontent.ftun6-1.fna.fbcdn.net/v/t1.0-1/p720x720/17629739_661947114149166_6086201923177778760_n.png?_nc_cat=103&_nc_ht=scontent.ftun6-1.fna&oh=b248a78916f16409356bdba4cf746f01&oe=5C73CBC5' style = 'width:40%;height:250;margin-left:5%' class='CToWUd'>" +
    "<div style = 'margin-left:7%' >" +
        "<h3> Welcome " + r.FirstName + " " + r.LastName + ",</h3>" +
        "<p>You are assigned to a new mandate, please check your account</p>" +
        "<h3>Mandate details :</h3>" +
        "<table>" +
            "<tbody>" +
               " <tr><td><b>Start date :</b></td><td>" + mandateModel.StartDate + "</td></tr>" +
                "<tr><td><b>End date:</b></td><td>" + mandateModel.EndDate + "</td></tr>" +
           " </tbody>" +
       " </table>" +
       " <p>" +
          "  You can access to our website : <a href = 'https://www.levio.ca' style= 'color:#253c93;text-decoration:none' > www.levio.ca </a>" +
        "</p> " +
    "</div>" +
"</div> ";

                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("sabrine.gmati25@gmail.com", "Espritsabrine100");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                return RedirectToAction("Index");

            }


            //




            return View(mandateModel);

        }

        // GET: Mandate/Edit/5
        public ActionResult Edit(int id)
        {
            var mandate = mandateModels.Find(e => e.MandateId == id);
            return View(mandate);
        }

        // POST: Mandate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdResource,IdProject,MandateId,StartDate,EndDate,Fees")] MandateModel mandateModel)
        {
            if (ModelState.IsValid)
            {
                var m = mandates.Where(e => e.MandateId == mandateModel.MandateId).FirstOrDefault();


                m.EndDate = mandateModel.EndDate;
                m.Fees = mandateModel.Fees;
                m.IdProject = mandateModel.IdProject;
                m.IdResource = mandateModel.IdResource;
                m.StartDate = mandateModel.StartDate;

                s.UpdateMandate(m);
                s.Commit();
                return RedirectToAction("Index");
            }
            //ViewBag.IdMandateHistory = new SelectList(db.MandateHistoryModels, "IdMandateHistory", "IdMandateHistory", mandateModel.IdMandateHistory);
            return View(mandateModel);
        }

        // GET: Mandate/Delete/5
        public ActionResult Delete(int id)
        {
            var mandate = mandateModels.Find(e => e.MandateId.Equals(id));
            return View(mandate);
        }

        // POST: Mandate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            var mandate = s.GetMandates().ToList().Where(e => e.MandateId == id).FirstOrDefault();
            //var mandate = mandates.FirstOrDefault(e => e.MandateId.Equals(id));


            s.DeleteMandate(mandate);
            //db.MandateModels.Add(mandateModel);
            s.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



    }
}


