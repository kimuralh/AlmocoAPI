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
    public class UsuariosController : ApiController
    {
        private AlmocoAPIContext db = new AlmocoAPIContext();

        // GET: api/Usuarios
        public IQueryable<UsuarioCapenga> GetUsuarios()
        {
            var usuarios = from u in db.Usuarios
                           select new UsuarioCapenga()
                           {
                               UsuarioId = u.UsuarioId,
                               UsuarioCpf = u.UsuarioCpf,
                               UsuarioNome = u.UsuarioNome,
                               UsuarioSaldo = u.UsuarioSaldo,
                               UsuarioEmail = u.UsuarioEmail
                           };

            return usuarios;
        }
        /*
        public IQueryable<Usuario> GetUsuarios()
        {
            return db.Usuarios;
        }
        */


        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult GetUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.UsuarioId)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        //[ResponseType(typeof(Usuario))]
        [ResponseType(typeof(UsuarioCapenga))]
        public IHttpActionResult PostUsuario(UsuarioCapenga usuariocapenga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario usuario = new Usuario()
            {

                UsuarioCpf = usuariocapenga.UsuarioCpf,
                UsuarioNome = usuariocapenga.UsuarioNome,
                UsuarioSaldo = usuariocapenga.UsuarioSaldo,
                UsuarioEmail = usuariocapenga.UsuarioEmail

            };

            db.Usuarios.Add(usuario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usuario.UsuarioId }, usuario);
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult DeleteUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuario);
            db.SaveChanges();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuarios.Count(e => e.UsuarioId == id) > 0;
        }
    }
}