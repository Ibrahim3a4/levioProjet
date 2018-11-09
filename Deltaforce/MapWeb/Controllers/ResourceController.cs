using Data;
using Domain.Entity;
using MapWeb.Models;
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
    public class ResourceController : Controller
    {
        ServiceResource sv = new ServiceResource();
        LevioMapCtx db = new LevioMapCtx();
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource sk = db.Resource.Find(id);
            if (sk == null)
            {
                return HttpNotFound();
            }
            return View(sk);
        }

        // GET: Resource/Create
        public ActionResult Create()
        {

            //Resource d = new Resource();
            //d. = sp.GetMany().Select(s => new SelectListItem
            //{
            //    Text = s.nomSpeciality,
            //    Value = s.SpecialityId.ToString()

            //});

            return View();
        }

        // POST: Resource/Create
        [HttpPost]
        public ActionResult Create(Resource rm)
        {
            try
            {
                Resource rc = new Resource
            {
                    
                    LastName = rm.LastName,
                    FirstName = rm.FirstName,
                    Gender = rm.Gender,
                    Seniority = rm.Seniority,
                    BusinessProfile = rm.BusinessProfile,
                    Rating = rm.Rating,
                    CV = rm.CV,
                    Photo = rm.Photo,
                    HiringDate = rm.HiringDate,
                    Salary = rm.Salary,
                    UserName = rm.UserName,
                    Email = rm.Email,
                    EmailConfirmed = true,
                    PasswordHash = rm.PasswordHash,
                    SecurityStamp = rm.SecurityStamp,
                    PhoneNumber = rm.PhoneNumber,
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = true,
                    LockoutEnabled = true,
                    LockoutEndDateUtc = rm.LockoutEndDateUtc,
                    AccessFailedCount = rm.AccessFailedCount,
                    InterMandateId = 2




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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource sk = sv.GetById(id);
            if (sk == null)
            {
                return HttpNotFound();
            }

            return View(sk);
        }

        // POST: Resource/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,LastName, FirstName,Gender,Seniority,BusinessProfile,Rating,CV,Photo,HiringDate,Salary,UserName,Email, PhoneNumber,InterMandateId")] Resource rs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rs);
        }

        // GET: Resource/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resource sc = sv.GetById(id);
            if (sc == null)
            {
                return HttpNotFound();
            }

            return View(sc);
        }

        // POST: Resource/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Resource rs)
        {
            try
            {
                var req = sv.GetMany().Where(a => a.Id == id).FirstOrDefault();
                sv.Delete(req);
                sv.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
