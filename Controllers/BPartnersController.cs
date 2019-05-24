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
using latihanazure.Models;

namespace latihanazure.Controllers
{
    public class BPartnersController : ApiController
    {
        private BPartnerDBContext db = new BPartnerDBContext();

        // GET: api/BPartners
        public IQueryable<BPartner> GetbPartners()
        {
            return db.bPartners;
        }

        // GET: api/BPartners/5
        [ResponseType(typeof(BPartner))]
        public IHttpActionResult GetBPartner(int id)
        {
            BPartner bPartner = db.bPartners.Find(id);
            if (bPartner == null)
            {
                return NotFound();
            }

            return Ok(bPartner);
        }

        // PUT: api/BPartners/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBPartner(int id, BPartner bPartner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bPartner.BPartnerID)
            {
                return BadRequest();
            }

            db.Entry(bPartner).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BPartnerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BPartners
        [ResponseType(typeof(BPartner))]
        public IHttpActionResult PostBPartner(BPartner bPartner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.bPartners.Add(bPartner);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bPartner.BPartnerID }, bPartner);
        }

        // DELETE: api/BPartners/5
        [ResponseType(typeof(BPartner))]
        public IHttpActionResult DeleteBPartner(int id)
        {
            BPartner bPartner = db.bPartners.Find(id);
            if (bPartner == null)
            {
                return NotFound();
            }

            db.bPartners.Remove(bPartner);
            db.SaveChanges();

            return Ok(bPartner);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BPartnerExists(int id)
        {
            return db.bPartners.Count(e => e.BPartnerID == id) > 0;
        }
    }
}