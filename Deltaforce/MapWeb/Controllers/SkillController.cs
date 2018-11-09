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
/// <summary>
/// ////////-///////////
/// </summary>
namespace MapWeb.Controllers
{
    public class SkillController : Controller
    {
        ServiceSkill ss = new ServiceSkill();

        LevioMapCtx db = new LevioMapCtx();
        
        // GET: Skill
        public ActionResult Index()
        {
            //var resou = ss.GetMany();
            //return View(resou);
            return View(db.Skill.ToList());
           
            
        }

        [HttpPost]
        public ActionResult Index(String SearchString)
        {
            var sk = ss.GetMany(p => p.SkillName.StartsWith(SearchString));
            return View(sk);
        }

        // GET: Skill/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill sk = db.Skill.Find(id);
            if (sk == null)
            {
                return HttpNotFound();
            }
            return View(sk);
        }

        // GET: Skill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skill/Create
        [HttpPost]
        public ActionResult Create(SkillModel sm)
        {
            try
            {
                Skill sk = new Skill
                {
                    SkillName = sm.SkillName,


                };

                ss.Add(sk);
                ss.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Skill/Edit/5
        public ActionResult Edit(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill sk = ss.GetById(id);
            if (sk == null)
            {
                return HttpNotFound();
            }

            return View(sk);
        }

        // POST: Skill/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "SkillId,SkillName")] Skill sk)
        {
            //if (ModelState.IsValid)
            //{   
            //    ss.Update(sk);
            //    return RedirectToAction("Index");
            //}
            //return View(sk);

            if (ModelState.IsValid)
            {
                db.Entry(sk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(sk);

        }

        // GET: Skill/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill sk = ss.GetSkillById(id);
            if (sk == null)
            {
                return HttpNotFound();
            }

            return View(sk);
        }

        // POST: Skill/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SkillModel sm)
        {
            try
            {
                var req = ss.GetMany().Where(a => a.SkillId == id).FirstOrDefault();
                ss.Delete(req);
                ss.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
