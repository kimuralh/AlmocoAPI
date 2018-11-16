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
using AlmocoAPI.Domain;
using AlmocoAPI.Models;
using AlmocoAPI.Repositories;

namespace AlmocoAPI.Controllers
{
    public class UsuariosController : ApiController
    {
        private AlmocoAPIContext db = new AlmocoAPIContext();

        private UsuarioService usuarioService;
        
        // GET: api/Usuarios
        public IEnumerable<UsuarioRetorno> GetUsuarios()
        {
            this.usuarioService = new UsuarioService();
            return this.usuarioService.Get();

            //var usuarios = from u in db.Usuarios


            /*
            var unitOfWork = new UnitOfWork(new AlmocoAPIContext());

            var usuarios = from u in unitOfWork.Usuarios.GetAll()

                           select new UsuarioRetorno(u);
                               
            unitOfWork.Complete();
            */
            //return usuarios;


        }

        /*
        public IQueryable<Usuario> GetUsuarios()
        {
            return db.Usuarios;
        }
        */


        // GET: api/Usuarios/5
        [ResponseType(typeof(UsuarioRetorno))]
        public IHttpActionResult GetUsuario(int id)
        {
            var unitOfWork = new UnitOfWork(new AlmocoAPIContext());
            var usuario = unitOfWork.Usuarios.Get(id);
            if (usuario == null)
            {
                return NotFound();
            }
            //var usuarioretorno = new UsuarioRetorno(usuario);
            
            var usuarioretorno = new UsuarioRetornoGrupo(usuario);
            unitOfWork.Complete();
            return Ok(usuarioretorno);
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
        [ResponseType(typeof(UsuarioCadastro))]
        public IHttpActionResult PostUsuario(UsuarioCadastro usuariocadastro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario usuario = new Usuario()
            {

                UsuarioCpf = usuariocadastro.UsuarioCpf,
                UsuarioNome = usuariocadastro.UsuarioNome,
                UsuarioSaldo = usuariocadastro.UsuarioSaldo,
                UsuarioEmail = usuariocadastro.UsuarioEmail

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