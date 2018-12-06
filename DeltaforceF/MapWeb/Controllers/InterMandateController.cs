using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using MapWeb.Models;
using Service;
using Domain.Entity;

namespace MapWeb.Controllers
{
    public class InterMandateController : Controller
    {
        private MapWebContext db = new MapWebContext();
        IServiceInterMandate si = new ServiceInterMandate();
        IServiceResourceSabrine s = new ServiceResourceSabrine();
        List<InterMandateModel> IntermandateModels;
        IEnumerable<InterMandate> Intermandates;



        public InterMandateController()
        {
            IntermandateModels = new List<InterMandateModel>();
            Intermandates = si.GetInterMandates();
            foreach (var m in Intermandates)
            {
                
                ICollection<ResourceModel> resources = new List<ResourceModel>();
                foreach(var r in s.GetResourceByInterMandate(m.InterMandateId).ToList())
                {
                    ResourceModel rm = new ResourceModel() { Id = r.Id, FirstName =  r.FirstName ,LastName = r.LastName};
                    resources.Add(rm);
                }
                InterMandateModel md = new InterMandateModel() { EndDate = m.EndDate, InterMandateId = m.InterMandateId, StartDate = m.StartDate};
                IntermandateModels.Add(md);
            }


        }

        // GET: InterMandate
        public ActionResult Index()
        {
            return View(IntermandateModels.ToList());
        }

        // GET: InterMandate/Details/5
        public ActionResult Details(int? id)
        {
            var Intermandate = IntermandateModels.Find(e => e.InterMandateId == id);


            return View(Intermandate);
        }
       

        // GET: InterMandate/Create
        public ActionResult Create()
        {
            ViewBag.IdMandateHistory = new SelectList(db.MandateHistoryModels, "IdMandateHistory", "IdMandateHistory");
            return View();
        }

        // POST: InterMandate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InterMandateId,StartDate,EndDate,Resources")] InterMandateModel interMandateModel)
        {
            
            InterMandate im = new InterMandate() { InterMandateId = 1, EndDate = interMandateModel.EndDate, StartDate = interMandateModel.StartDate};
            si.AddInterMandate(im);
            //db.MandateModels.Add(mandateModel);
            return RedirectToAction("Index");
        }

        // GET: InterMandate/Edit/5
        public ActionResult Edit(int? id)
        {
            var Intermandate = IntermandateModels.Find(e => e.InterMandateId == id);
            return View(Intermandate);
        }

        // POST: InterMandate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InterMandateId,StartDate,EndDate")] InterMandateModel interMandateModel)
        {
            if (ModelState.IsValid)
            {
                var im = Intermandates.Where(e => e.InterMandateId == interMandateModel.InterMandateId).FirstOrDefault();


                im.EndDate = interMandateModel.EndDate;
                im.StartDate = interMandateModel.StartDate;

                si.UpdateInterMandate(im);
                return RedirectToAction("Index");
            }
            //ViewBag.IdMandateHistory = new SelectList(db.MandateHistoryModels, "IdMandateHistory", "IdMandateHistory", mandateModel.IdMandateHistory);
            return View(interMandateModel);
        }

        // GET: InterMandate/Delete/5
        public ActionResult Delete(int? id)
        {
            var Intermandate = IntermandateModels.Find(e => e.InterMandateId == id);
            return View(Intermandate);

        }

        // POST: InterMandate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var Intermandate = Intermandates.Where(e => e.InterMandateId == id).FirstOrDefault();


            si.DeleteInterMandate(Intermandate);
            //db.MandateModels.Add(mandateModel);
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
