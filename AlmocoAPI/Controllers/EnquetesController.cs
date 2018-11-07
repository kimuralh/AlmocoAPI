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
using AlmocoAPI.Models;

namespace AlmocoAPI.Controllers
{
    public class EnquetesController : ApiController
    {
        private AlmocoAPIContext db = new AlmocoAPIContext();

        // GET: api/Enquetes
        public IQueryable<Enquete> GetEnquetes()
        {
            return db.Enquetes;
        }

        // GET: api/Enquetes/5
        [ResponseType(typeof(Enquete))]
        public IHttpActionResult GetEnquete(int id)
        {
            Enquete enquete = db.Enquetes.Find(id);
            if (enquete == null)
            {
                return NotFound();
            }

            return Ok(enquete);
        }

        // PUT: api/Enquetes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEnquete(int id, Enquete enquete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != enquete.EnqueteId)
            {
                return BadRequest();
            }

            db.Entry(enquete).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnqueteExists(id))
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

        // POST: api/Enquetes
        [ResponseType(typeof(Enquete))]
        public IHttpActionResult PostEnquete(Enquete enquete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Enquetes.Add(enquete);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = enquete.EnqueteId }, enquete);
        }

        // DELETE: api/Enquetes/5
        [ResponseType(typeof(Enquete))]
        public IHttpActionResult DeleteEnquete(int id)
        {
            Enquete enquete = db.Enquetes.Find(id);
            if (enquete == null)
            {
                return NotFound();
            }

            db.Enquetes.Remove(enquete);
            db.SaveChanges();

            return Ok(enquete);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnqueteExists(int id)
        {
            return db.Enquetes.Count(e => e.EnqueteId == id) > 0;
        }
    }
}