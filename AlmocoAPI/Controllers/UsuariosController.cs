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

        /* exemplo de cabecalho
        [HttpPost]
        [Route("monitorar/{idEstabelecimento}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(ActionResultModel))]
        */




        ///
        /// <summary>
        /// 	Retorna todos os usuários com menos detalhes
        /// </summary>
        ///
        // GET: api/Usuarios
        [HttpGet]
        [Route("usuarios")]
        public IEnumerable<UsuarioComId> GetUsuarios()
        {
            this.usuarioService = new UsuarioService();
            return this.usuarioService.GetUsuarios();

            //var usuarios = from u in db.Usuarios


            /*
            var unitOfWork = new UnitOfWork(new AlmocoAPIContext());

            var usuarios = from u in unitOfWork.Usuarios.GetAll()

                           select new UsuarioComId(u);
                               
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

        ///
        /// <summary>
        /// 	Retorna o Usuário com o respectivo id, junto com os grupos aos quais pertence
        /// </summary>
        ///
        // GET: api/Usuarios/5
        [HttpGet]
        [Route("usuarios/{idUsuario}")]
        [ResponseType(typeof(UsuarioComId))]
        public IHttpActionResult GetUsuario(int idUsuario)
        {
            this.usuarioService = new UsuarioService();
            return Ok(this.usuarioService.GetUsuario(idUsuario));

        }

        ///
        /// <summary>
        /// 	Atualiza as informações de um usuário com o respectivo id
        /// </summary>
        ///
        // PUT: api/Usuarios/5
        [HttpPut]
        [Route("usuarios/{idUsuario}")]
        public IHttpActionResult PutUsuario(int idUsuario, [FromBody] UsuarioCadastro usuario)
        {
            this.usuarioService = new UsuarioService();
            var resultado = this.usuarioService.PutUsuario(idUsuario, usuario);
            if (resultado)
            {
                return Content(HttpStatusCode.OK,"Usuario Alterado com sucesso");
            }
            return Content(HttpStatusCode.BadRequest, "Não foi possivel alterar este usuario");
            /*
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
            */

            return StatusCode(HttpStatusCode.NoContent);
        }

        ///
        /// <summary>
        /// 	Cadastra um usuário de posse das informações de cadastro
        /// </summary>
        ///
        // POST: api/Usuarios
        //[ResponseType(typeof(Usuario))]
        [ResponseType(typeof(UsuarioCadastro))]
        public IHttpActionResult PostUsuario(UsuarioCadastro usuariocadastro)
        {
            this.usuarioService = new UsuarioService();
            var resultado = this.usuarioService.PostUsuario(usuariocadastro);
            if (resultado != false)
            {
                return Content(HttpStatusCode.OK, "Usuario cadastrado com sucesso");
            }
            return Content(HttpStatusCode.BadRequest, "Não foi possivel cadastrar este usuario, CPF já existente");

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

        
        
    }
}