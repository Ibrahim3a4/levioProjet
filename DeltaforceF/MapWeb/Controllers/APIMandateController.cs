using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Data;
using MapWeb.Models;
using Service;
using Domain.Entity;

namespace MapWeb.Controllers
{
    public class APIMandateController : ApiController
    {
        //private LevioMapCtx db = new LevioMapCtx();
        ServiceMandate sm = new ServiceMandate();
        //private MapWebContext db = new MapWebContext();
        // GET: api/APIMandate
        public IEnumerable<Mandate> GetMandate()
        {
            return sm.GetMandates();
        }

        // // GET: api/APIMandate/5
        [ResponseType(typeof(Mandate))]
        public IHttpActionResult GetMandateModel(int id)
        {
            Mandate mandate = sm.GetMandate(id);
            if (mandate == null)
            {
                return NotFound();
            }

            return Ok(mandate);
        }

        // PUT: api/APIMandate/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMandateModel(string id, Mandate mandateModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != mandateModel.IdResource)
            //{
            //    return BadRequest();
            //}

            sm.UpdateMandate(mandateModel);

            //try
            //{
            //    db.SaveChanges();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!MandateModelExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/APIMandate
        [ResponseType(typeof(MandateModel))]
        public IHttpActionResult PostMandateModel(Mandate mandate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.MandateModels.Add(mandateModel);
            sm.AddMandate(mandate);

         
            //catch (DbUpdateException)
            //{
            //    if (MandateModelExists(mandateModel.IdResource))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return CreatedAtRoute("DefaultApi", new { id = mandate.IdResource }, mandate);
        }

        // DELETE: api/APIMandate
        [ResponseType(typeof(MandateModel))]
        public IHttpActionResult DeleteMandateModel(int id)
        {
            var m = sm.GetMandate(id);
            if (m == null)
            {
                return NotFound();
            }
            sm.DeleteMandate(m);
            return Ok();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool MandateModelExists(string id)
        //{
        //    return sm.Mandate.Count(e => e.IdResource == id) > 0;
        //}
    }
}