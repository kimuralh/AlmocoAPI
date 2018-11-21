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

namespace AlmocoAPI.Controllers
{

    ///
    /// <summary>
    /// 	Controller responsável pelas ações de voto
    /// </summary>
    ///
    public class VotosController : ApiController
    {
        private AlmocoAPIContext db = new AlmocoAPIContext();
        private VotoService votoService;
        ///
        /// <summary>
        /// 	Retorna todos os votos
        /// </summary>
        ///
        // GET: api/votos
        [HttpGet]
        [Route("votos")]
        public IEnumerable<VotoSimples> GetVotos()
        {
            this.votoService = new VotoService();
            return this.votoService.GetVotos();
        }


        ///
        /// <summary>
        /// 	Retorna um voto com detalhes
        /// </summary>
        ///
        // GET: api/Votos/5
        [HttpGet]
        [Route("votos/{idVoto}")]
        [ResponseType(typeof(VotoSimples))]
        public VotoSimples GetVoto(int idVoto)
        {

            this.votoService = new VotoService();
            return this.votoService.GetVoto(idVoto);

        }

        ///
        /// <summary>
        /// 	Retorna os votos registrados de um usuario
        /// </summary>
        ///
        // GET: api/Votos/5
        [HttpGet]
        [Route("usuarios/{idUsuario}/votos")]
        [ResponseType(typeof(VotoSimples))]
        public IEnumerable<VotoSimples> GetVotosUsuario(int idUsuario)
        {

            this.votoService = new VotoService();
            return this.votoService.GetVotosUsuario(idUsuario);

        }

        ///
        /// <summary>
        /// 	Altera um dos votos de um usuario
        /// </summary>
        ///
        // PUT: api/Votos/5
        //tem que ser tudo identico exceto o restaurante votado
        [HttpPut]
        [Route("votos")]
        public IHttpActionResult PutVoto([FromBody] VotoAlterado voto)
        {
            this.votoService = new VotoService();
            var resultado = this.votoService.PutVoto(voto);
            if (resultado)
            {
                return Content(HttpStatusCode.OK, "Voto Alterado com sucesso");
            }
            return Content(HttpStatusCode.BadRequest, "Não foi possivel alterar este voto");
        }

        ///
        /// <summary>
        /// 	Registra um voto
        /// </summary>
        ///
            // POST: api/Votos
        [HttpPost]
        [Route("Enquete/")]

        public IHttpActionResult PostVoto(VotoCadastro voto)
        {

            this.votoService = new VotoService();
            var resultado = this.votoService.PostVoto(voto);

            if (resultado)
            {
                return Content(HttpStatusCode.OK, "Voto Cadastrado com sucesso");
            }
            return Content(HttpStatusCode.BadRequest, "Não foi possivel votar nesta enquete");
            

        }

        ///
        /// <summary>
        /// 	Deleta um voto
        /// </summary>
        ///
        // DELETE: api/Votos/5

    }

}