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
    public class SkillController : Controller
    {
        ServiceSkill ss = new ServiceSkill();
        
        // GET: Skill
        public ActionResult Index()
        {
            var resou = ss.GetMany();
            return View(resou);
        }

        // GET: Skill/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                  Level = sm.Level

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
           
            return View();
        }

        // POST: Skill/Edit/5
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

        // GET: Skill/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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
