using Data;
using Domain.Entity;
using MapWeb.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Controllers
{
    public class SkillResourceController : Controller
    {
        ServiceSkillResource sc = new ServiceSkillResource();
        ServiceSkill sk = new ServiceSkill();
        ServiceResource sr = new ServiceResource();

        LevioMapCtx db = new LevioMapCtx();


        // GET: SkillResource
        public ActionResult Index()
        {


            //return View(db.SkillResource.ToList());
            var assigned = db.SkillResource.Include("Resource").Include("Skill");
            return View(assigned);

        }

        // GET: SkillResource/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SkillResource/Create
        public ActionResult Create()
        {
            SkillResourceModel pm = new SkillResourceModel();
            pm.Skills = sk.GetMany().Select(c => new SelectListItem
            {
                Text = c.SkillName,
                Value = c.SkillId.ToString(),

            });
            pm.Resources = sr.GetMany().Select(e => new SelectListItem
            {
                Text = e.FirstName,
                Value = e.Id,

            });


            return View(pm);


        }

        // POST: SkillResource/Create
        [HttpPost]
        public ActionResult Create(SkillResourceModel skm)
        {
            try
            {
                SkillResource sk = new SkillResource
                {
                    ResourceIdFK = skm.ResourceIdFK,
                    SkillIdFK = skm.SkillIdFK,
                    Level = skm.Level




                };

                sc.Add(sk);
                sc.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: SkillResource/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SkillResource/Edit/5
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

        // GET: SkillResource/Delete/5
        public ActionResult Delete(int id, String id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SkillResource sk = sc.GetMany().Where(a => a.SkillIdFK == id).Where(b => b.ResourceIdFK == id2).FirstOrDefault();
            if (sk == null)
            {
                return HttpNotFound();
            }

            return View(sk);
        }

        // POST: SkillResource/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SkillResource sr, String id2)
        {
            try
            {
                var req = sc.GetMany().Where(a => a.SkillIdFK == id).Where(b => b.ResourceIdFK == id2).FirstOrDefault();
                sc.Delete(req);
                sc.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
