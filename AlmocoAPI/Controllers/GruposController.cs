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
using AlmocoAPI.DTO;
using AlmocoAPI.Models;
using AlmocoAPI.Repositories;

namespace AlmocoAPI.Controllers
{
    public class GruposController : ApiController
    {
        private AlmocoAPIContext db = new AlmocoAPIContext();

        private GrupoService grupoService;
        ///
        /// <summary>
        /// 	Retorna todos os grupos
        /// </summary>
        ///
        // GET: api/grupos
        [HttpGet]
        [Route("grupos")]
        public IEnumerable<GrupoRetorno> GetGrupos()
        {
            this.grupoService = new GrupoService();
            var grupos = grupoService.GetGrupos();

            return grupos;
        }

        ///
        /// <summary>
        /// 	Retorna o grupo com o id
        /// </summary>
        ///
        // GET: api/Grupos/5
        [Route("grupos/{idGrupo}")]

        public IHttpActionResult GetGrupo(int idGrupo)
        {
            this.grupoService = new GrupoService();

            var grupo = grupoService.GetGrupo(idGrupo);
            if (grupo == null)
            {
                return Content(HttpStatusCode.NotFound , "Grupo não encontrado");
            }
            return Content(HttpStatusCode.OK, grupo);
        }
        //=======================================================
        ///
        /// <summary>
        /// 	Retorna os usuarios do grupo
        /// </summary>
        ///
        // GET: api/grupos/5/membros
        [Route("grupos/{idGrupo}/membros")]

        public IHttpActionResult GetMembrosGrupo(int idGrupo)
        {
            this.grupoService = new GrupoService();

            var membros = grupoService.GetMembrosGrupo(idGrupo);

            return Content(HttpStatusCode.OK, membros);
        }
        
        ///
        /// <summary>
        /// 	Adiciona um usuario existente ao grupo
        /// </summary>
        ///
        // POST: api/grupos/5/membros/1
        [Route("grupos/{idGrupo}/membros/")]

        public IHttpActionResult AdicionaMembroGrupo(int idGrupo,[FromBody] int idUsuario)
        {
            this.grupoService = new GrupoService();
            var retorno = this.grupoService.AdicionaMembroGrupo(idGrupo, idUsuario);
            if (retorno == null)
            {
                return Content(HttpStatusCode.BadRequest, "Não foi possivel cadastrar esse usuario neste grupo");
            }
            return Content(HttpStatusCode.OK, "Usuario "+ retorno.UsuarioNome +" foi cadastrado no grupo de id"+idGrupo+"com sucesso");

        }
        /*
        //==========================================================
        ///
        /// <summary>
        /// 	Retorna os restaurantes do grupo
        /// </summary>
        ///
        // GET: api/grupos/5/restaurantes
        [Route("grupos/{idGrupo}/restaurantes")]

        public IHttpActionResult GetRestaurantesGrupo(int idGrupo)
        {
            this.grupoService = new GrupoService();

            var restaurantes = grupoService.GetRestaurantesGrupo(idGrupo);
            
            return Content(HttpStatusCode.OK, restaurantes);
        }
        */
        
        ///
        /// <summary>
        /// 	Adiciona um restaurante existente ao grupo
        /// </summary>
        ///
        // POST: api/grupos/5/restaurantes/
        [Route("grupos/{idGrupo}/restaurantes/")]

        public IHttpActionResult AdicionaRestauranteGrupo(int idGrupo, [FromBody] int idRestaurante)
        {
            this.grupoService = new GrupoService();
            var retorno = this.grupoService.AdicionaRestauranteGrupo(idGrupo, idRestaurante);
            if (retorno == null)
            {
                return Content(HttpStatusCode.BadRequest, "Não foi possivel cadastrar esse restaurante neste grupo");
            }
            return Content(HttpStatusCode.OK, "Restaurante " + retorno.RestauranteNome + " foi cadastrado no grupo de id " + idGrupo + "com sucesso");


        }





        /*
        ///
        /// <summary>
        /// 	Cadastra um grupo de acordo com as informações de cadastro
        /// 	Detalhe que a adição de membros se faz em outro endpoint
        /// </summary>
        ///
        // POST: api/grupos
        [HttpPost]
        [Route("grupos/")]
        public IHttpActionResult PostCadastroGrupo([FromBody] GrupoCadastro grupo)
        {
            this.grupoService = new GrupoService();
            var resultado = this.grupoService.PostCadastroGrupo(grupo);
            if (resultado != false)
            {
                return Content(HttpStatusCode.OK, "Grupo cadastrado com sucesso");
            }
            return Content(HttpStatusCode.BadRequest, "Não foi possivel cadastrar este Grupo");


        }
        */

        ///
        /// <summary>
        /// 	Deleta um grupo de posse do seu id
        /// </summary>
        ///
        // DELETE: api/grupos/5
        [HttpDelete]
        [Route("grupos/{idGrupo}")]
   
        public IHttpActionResult DeleteGrupo(int id)
        {
            this.grupoService = new GrupoService();
            var resposta = this.grupoService.DeleteGrupo(id);

            if (resposta == false)
            {
                return Content(HttpStatusCode.NotFound, "Grupo não encontrado");
            }
            else
            {
                return Content(HttpStatusCode.OK, "Grupo deletado com sucesso");
            }

        }


    }
}