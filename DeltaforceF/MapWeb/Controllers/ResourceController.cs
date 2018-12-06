using Data;
using Domain.Entity;
using MapWeb.Models;
using MapWeb.Report;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Service;
using Service.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
        ServiceHistory sh = new ServiceHistory();
        ServiceInterMandate si = new ServiceInterMandate();

        // GET: Resource
        public ActionResult Index()
        {
            //var currNam = HttpContext.User.Identity.GetUserName();
            //ViewBag.UserFirstName = currNam;
            //var req = sv.Get5MostRatedResource();
            //return View(req);
            

            var req = db.Resource;
            return View(req);
            //return View( db.Resource.ToListAsync());
        }



        public ActionResult TopResource()
        {
            var req = sv.Get5MostRatedResource().ToList();
            return View(req);


            
        }

        public ActionResult TopSalary()
        {
            var req = sv.GetResourceBySalary().ToList();
            return View(req);



        }

        // GET: Resource/Details/5
        public ActionResult Details(String id)
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
            //ResourceModel pm = new ResourceModel();
            //pm.Intermandates = si.GetMany().Select(c => new SelectListItem
            //{
            //    Text = c.StartDate.ToString(),
            //    Value = c.InterMandateId.ToString(),

            //});
            return View(/*pm*/);
        }

        // POST: Resource/Create
        [HttpPost]
        public ActionResult Create2(Resource rm )
        {
            //rm.Photo = Image.FileName;
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
                    //EmailConfirmed = true,
                    //PasswordHash = rm.PasswordHash,
                    //SecurityStamp = rm.SecurityStamp,
                    PhoneNumber = rm.PhoneNumber,
                    //PhoneNumberConfirmed = true,
                    TwoFactorEnabled = true,
                    //LockoutEnabled = true,
                    LockoutEndDateUtc = rm.LockoutEndDateUtc,
                    //AccessFailedCount = rm.AccessFailedCount,
                    InterMandateId = rm.InterMandateId




                };


            sv.Add(rc);
            sv.Commit();
                //var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                //Image.SaveAs(path);

                return RedirectToAction("Index");
        }
            catch
            {
                return View();
    }
}



        [HttpPost]
        public ActionResult Create(ResourceModel rm , HttpPostedFileBase Image )
        {
            rm.Photo = Image.FileName;
            
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
                    //EmailConfirmed = true,
                    //PasswordHash = rm.PasswordHash,
                    //SecurityStamp = rm.SecurityStamp,
                    PhoneNumber = rm.PhoneNumber,
                    //PhoneNumberConfirmed = true,
                    TwoFactorEnabled = true,
                    //LockoutEnabled = true,
                    LockoutEndDateUtc = rm.LockoutEndDateUtc,
                    //AccessFailedCount = rm.AccessFailedCount,
                    InterMandateId = rm.InterMandateId





                };


                sv.Add(rc);
                sv.Commit();
                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Image.FileName);
                Image.SaveAs(path);
                


                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }



        public ActionResult Report(Resource student)
        {
            StudentReport studentReport = new StudentReport();
                byte[] abytes = studentReport.PrepareReport(GetStudents());
            return File(abytes, "application/pdf");



        }

        public List<Resource> GetStudents()
        {
            List<Resource> students = new List<Resource>();
            Resource student = new Resource();
            for (int i=1;i<=6;i++)
            {
                student = new Resource();
                student.Id = student.Id;
                student.Email = student.Email;
                student.UserName = "bbbbbbbbbbbbbbb";
                students.Add(student);

            }
            return students;
        }



        // GET: Resource/Edit/5
        public ActionResult Edit(String id)
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
        public ActionResult Edit([Bind(Include = "Id,LastName,PasswordHash,SecurityStamp, FirstName,Gender,Photo,Seniority,BusinessProfile,Rating,CV,Photo,HiringDate,Salary,UserName,Email, PhoneNumber,InterMandateId")] Resource rs, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                String fileName = Path.GetFileName(Image.FileName);
                
                var resou = sv.GetMany().Single(em => em.Id == rs.Id);
                rs.PasswordHash = resou.PasswordHash;
                rs.SecurityStamp = resou.SecurityStamp;
                rs.Photo = fileName;
                


                db.Entry(rs).State = EntityState.Modified;
                
                db.SaveChanges();
                sv.Commit();
                return RedirectToAction("Index");
            }

            return View(rs);
        }

        // GET: Resource/Delete/5
        public ActionResult Delete(String id)
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
        public ActionResult Delete(String id, Resource rs)
        {
            try
            {
                var req = sv.GetMany().Where(a => a.Id == id).FirstOrDefault();

                ResourceHistory rh = new ResourceHistory
                {
                    FirstName = req.FirstName,
                    LastName = req.LastName,
                    Username = req.UserName
                };

                sh.Add(rh);
                sh.Commit();

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
