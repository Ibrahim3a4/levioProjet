using System;
using System.Collections.Generic;
﻿using Data;
using Domain.Entity;
using MapWeb.Models;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Controllers
{
    public class ProjectController : Controller
    {

        IServiceProject sc = new ServiceProject();
        LevioMapCtx db = new LevioMapCtx();
        // GET: Project
        public ActionResult Index()
        {
            var res = sc.GetMany();
            return View(res);
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Project/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        public ActionResult Create(Project pa, HttpPostedFileBase Imag)
        {
            pa.Image = Imag.FileName;
            try
            {
                Project p = new Project
                {
                    Project_id = pa.Project_id,
                    Name = pa.Name,

                    StartDate = pa.StartDate,
                    EndDate = pa.EndDate,
                    Address = pa.Address,
                    TotalNbrLevio = pa.TotalNbrLevio,
                    TotalNbrRessources = pa.TotalNbrRessources,
                    Type = pa.Type,
                    Image = pa.Image
                };

                var path = Path.Combine(Server.MapPath("~/Content/Upload/"), Imag.FileName);
                Imag.SaveAs(path);
                if (ModelState.IsValid)
                {
                    sc.Add(p);
                    sc.Commit();
                    return RedirectToAction("Index");
                }
                
                return View(p);
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            Project p = sc.GetById(id);
            Project p1 = new Project();
            p1.Address = p.Address;
            p1.StartDate = p.StartDate;
            p1.EndDate = p.EndDate;
            p1.Name = p.Name;
            p1.TotalNbrLevio = p.TotalNbrLevio;
            p1.TotalNbrRessources = p.TotalNbrRessources;
            p1.Type = p.Type;
            if (p1 == null)
            {
                return HttpNotFound();

            }
            return View(p1);
        }

        // POST: Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Project p)
        {
            Project p1 = sc.GetById(id);
            p1.Address = p.Address;
            p1.StartDate = p.StartDate;
            p1.EndDate = p.EndDate;
            p1.Name = p.Name;
            p1.TotalNbrLevio = p.TotalNbrLevio;
            p1.TotalNbrRessources = p.TotalNbrRessources;
            p1.Type = p.Type;
            if (ModelState.IsValid)
            {
                sc.Update(p1);
                sc.Commit();
                return RedirectToAction("Index");
            }

            return View(p);
        }
       
        

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            Project p = sc.GetById(id);
            Project p1 = new Project();
            p1.Address = p.Address;
            p1.StartDate = p.StartDate;
            p1.EndDate = p.EndDate;
            p1.Name = p.Name;
            p1.TotalNbrLevio = p.TotalNbrLevio;
            p1.TotalNbrRessources = p.TotalNbrRessources;
            p1.Type = p.Type;
            if (p1 == null)
            {
                return HttpNotFound();

            }
            return View(p1);
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Project p)
        {
            Project p1 = sc.GetById(id);
            p1.Address = p.Address;
            p1.StartDate = p.StartDate;
            p1.EndDate = p.EndDate;
            p1.Name = p.Name;
            p1.TotalNbrLevio = p.TotalNbrLevio;
            p1.TotalNbrRessources = p.TotalNbrRessources;
            p1.Type = p.Type;
            sc.Delete(p1);
            sc.Commit();
            return RedirectToAction("Index");
        }

        
    }
}
