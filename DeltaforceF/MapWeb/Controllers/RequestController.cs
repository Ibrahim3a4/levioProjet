using Domain.Entity;
using Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Controllers
{
    public class RequestController : Controller
    {
        ServiceRequest sr = new ServiceRequest();
        // GET: Request
        public ActionResult Index()
        {
            var Requests = sr.GetMany();
            return View(Requests);
        }

        [HttpPost]
        public ActionResult Index(String SearchString)
        {
            var RequestsSearch = sr.GetMany(p => p.requirements == SearchString);
            return View(RequestsSearch);
        }

        // GET: Request/Details/5
        public ActionResult Details(int id)
        {
           
            return View();
        }

        // GET: Request/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Request/Create
        [HttpPost]
        public ActionResult Create(Request req)
        {
            try
            {
                Request Req = new Request
                { requirements=req.requirements,
                    profileRequired=req.profileRequired,
                    career=req.career,
                    startDate=req.startDate,
                    endDate=req.endDate,
                    //director=req.director,
                    depositDate=req.depositDate
          
                };
                // TODO: Add insert logic here
                sr.Add(req);
                sr.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Request/Edit/5
        public ActionResult Edit(int id)
        {
            Request req = sr.GetById(id);
            Request req1 = new Request();
            req1.requirements = req.requirements;
            req1.profileRequired = req.profileRequired;
            req1.career = req.career;
            req1.startDate = req.startDate;
            req1.endDate = req.endDate;
            req1.depositDate = req.depositDate;
            if (req1 == null)
            {
                return HttpNotFound();
            }

           
            return View(req1);
        }

        // POST: Request/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,Request req)
        { Request req1 = sr.GetById(id);
            req1.requirements = req.requirements;
            req1.profileRequired = req.profileRequired;
            req1.career = req.career;
            req1.startDate = req.startDate;
            req1.endDate = req.endDate;
            req1.depositDate = req.depositDate;
          
         sr.Update(req1);
         sr.Commit();
         return RedirectToAction("Index");
    
    
            
        }

        // GET: Request/Delete/5
        public ActionResult Delete(int id)
        {
            Request req = sr.GetById(id);
            Request req1 = new Request();
            req1.requirements = req.requirements;
            req1.profileRequired = req.profileRequired;
            req1.career = req.career;
            req1.startDate = req.startDate;
            req1.endDate = req.endDate;
            req1.depositDate = req.depositDate;
            if (req1 == null)
            {
                return HttpNotFound();
            }


            return View(req1);
        }

        // POST: Request/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Request req)
        {
            Request req1 = sr.GetById(id);
            req1.requirements = req.requirements;
            req1.profileRequired = req.profileRequired;
            req1.career = req.career;
            req1.startDate = req.startDate;
            req1.endDate = req.endDate;
            req1.depositDate = req.depositDate;

            sr.Delete(req1);
            sr.Commit();
            return RedirectToAction("Index");
        }
    }
}
