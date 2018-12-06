using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

using System.Net.Http;
using System.Web.Http;
using Data;
using Service;
using Domain.Entity;
using MapWeb.Models;

namespace MapWeb.Controllers
{
    public class SkillAPIController : ApiController
    {

        ServiceSkill cs = new ServiceSkill();
        LevioMapCtx db = new LevioMapCtx();

        [Route("api/skillList")]
        [HttpGet]
        public IHttpActionResult Index()
        {
            List<SkillModel> lcm = new List<Models.SkillModel>();
            foreach (var item in cs.GetMany())
            {
                SkillModel cm = new SkillModel();
                cm.SkillName = item.SkillName;
                lcm.Add(cm);
            }
            return Ok(lcm);
        }

        [Route("api/skilldetails/{id}")]
        [HttpGet]
        public IHttpActionResult Details(int id)
        {
            Skill sk = cs.GetById(id);
            return Ok(sk);
            
        }

        [Route("api/skilladd")]
        [HttpPost]
        public IHttpActionResult Create(SkillModel clt)
        {
            Skill c = new Skill();

            c.SkillName = clt.SkillName;
            cs.Add(c);
            cs.Commit();
            return Ok();

        }


        //[Route("api/skilldetail")]
        //[HttpGet]
        //public IHttpActionResult Details()
        //{

        //    List<SkillModel> lcm = new List<Models.SkillModel>();
        //    foreach (var item in cs.GetMany())
        //    {
        //        SkillModel cm = new SkillModel();
        //        cm.SkillName = item.SkillName;
        //        lcm.Add(cm);
        //    }
        //    return Ok(lcm);
        //}

        // GET: SkillAPI/Create

        //[System.Web.Http.HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: SkillAPI/Create

        //[System.Web.Http.Route("api/skillList")]
        //[System.Web.Http.HttpGet]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: SkillAPI/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        
        //public IHttpActionResult Edit()
        //{
            
        //}

        //// GET: SkillAPI/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        [Route("api/skilldel/{id}")]
        [HttpPost]
        public IHttpActionResult Delete(int id, SkillModel sm)
        {

            var req = cs.GetMany().Where(a => a.SkillId == id).FirstOrDefault();
            cs.Delete(req);
            cs.Commit();
            return Ok();
        }
    }
}
