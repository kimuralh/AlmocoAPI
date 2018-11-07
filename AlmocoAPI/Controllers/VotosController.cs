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
    public class VotosController : ApiController
    {
        private AlmocoAPIContext db = new AlmocoAPIContext();

        // GET: api/Votos
        public IQueryable<Voto> GetVotos()
        {
            return db.Votos;
        }

        // GET: api/Votos/5
        [ResponseType(typeof(Voto))]
        public IHttpActionResult GetVoto(int id)
        {
            Voto voto = db.Votos.Find(id);
            if (voto == null)
            {
                return NotFound();
            }

            return Ok(voto);
        }

        // PUT: api/Votos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVoto(int id, Voto voto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voto.VotoId)
            {
                return BadRequest();
            }

            db.Entry(voto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VotoExists(id))
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

        // POST: api/Votos
        [ResponseType(typeof(Voto))]
        public IHttpActionResult PostVoto(Voto voto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Votos.Add(voto);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = voto.VotoId }, voto);
        }

        // DELETE: api/Votos/5
        [ResponseType(typeof(Voto))]
        public IHttpActionResult DeleteVoto(int id)
        {
            Voto voto = db.Votos.Find(id);
            if (voto == null)
            {
                return NotFound();
            }

            db.Votos.Remove(voto);
            db.SaveChanges();

            return Ok(voto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VotoExists(int id)
        {
            return db.Votos.Count(e => e.VotoId == id) > 0;
        }
    }
}