using Domain.Entity;
using MapWeb.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Controllers
{
    public class ResourceController : Controller
    {
        ServiceResource sv = new ServiceResource();
        // GET: Resource
        public ActionResult Index()
        {
            //var req = sv.Get5MostRatedResource();
            //return View(req);

            var req = sv.GetMany();
            return View(req);
        }

        // GET: Resource/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Resource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resource/Create
        [HttpPost]
        public ActionResult Create( ResourceModel rm)
        {
            try
            {
                Resource rc = new Resource
                {  Seniority = rm.Seniority,
                    BusinessProfile = rm.BusinessProfile,
                    Rating = rm.Rating, 
                    CV = rm.CV,
                    Photo = rm.Photo,
                    HiringDate = rm.HiringDate, 
                    Salary = rm.Salary

                };

                sv.Add(rc);
                sv.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Resource/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Resource/Edit/5
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Resource/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
