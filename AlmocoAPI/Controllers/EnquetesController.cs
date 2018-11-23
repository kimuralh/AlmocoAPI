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
    public class EnquetesController : ApiController
    {
       
        private EnqueteService enqueteService;

        ///
        /// <summary>
        /// 	Retorna o numero de enquetes que o grupo com este id possui
        /// </summary>
        ///
        [HttpGet]
        [Route("grupos/{idGrupo}/numeroEnquetes")]
        public int GetNumeroEnquetes(int idGrupo)
        {
            this.enqueteService = new EnqueteService();
            int numero = enqueteService.GetNumeroEnquetes(idGrupo);
            return numero;
        }


        ///
        /// <summary>
        /// 	Paginação das enquetes do grupo com este id, considerando pagina atual e o numero de elementos por pagina
        /// </summary>
        ///
        [HttpGet]
        [Route("grupos/{idGrupo}/enquetes/{pagina}/{tamanhoPagina}")]
        public IEnumerable<EnqueteRetorno> GetPaginaEnquetes(int idGrupo, int pagina, int tamanhoPagina)
        {
            this.enqueteService = new EnqueteService();
            var enquetes = this.enqueteService.GetPaginaEnquetes(idGrupo,pagina,tamanhoPagina);
            return enquetes;
        }

        ///
        /// <summary>
        /// 	Cadastra uma enquete de posse do idGrupo à qual essa enquete irá pertencer
        /// </summary>
        ///
        // POST: api/enquetes
        [HttpPost]
        [Route("enquetes/")]
        public IHttpActionResult PostEnquete(EnqueteCadastro enqueteCadastro)
        {
            this.enqueteService = new EnqueteService();
            var resultado = this.enqueteService.PostEnquete(enqueteCadastro);

            if (resultado == null)
            {
                return Content(HttpStatusCode.BadRequest, "Não foi possivel cadastrar este enquete neste grupo");
                
            }
            else
            {
                return Content(HttpStatusCode.OK, "Enquete cadastrada com sucesso no grupo de id" + resultado.Grupo.GrupoId);
            }


        }

        ///
        /// <summary>
        /// 	Adiciona um restaurante existente à uma enquete existente
        /// </summary>
        ///
        // POST: api/enquetes/5/restaurantes/
        [Route("enquetes/{idEnquete}/restaurantes")]

        public IHttpActionResult AdicionaRestauranteEnquete(int idEnquete, [FromBody] int idRestaurante)
        {
            this.enqueteService = new EnqueteService();
            var retorno = this.enqueteService.AdicionaRestauranteEnquete(idEnquete, idRestaurante);
            if (retorno == null)
            {
                return Content(HttpStatusCode.BadRequest, "Não foi possivel cadastrar esse restaurante nesta enquete");
            }
            return Content(HttpStatusCode.OK, "Restaurante " + retorno.RestauranteNome + " foi cadastrado na enquete de id " + idEnquete + "com sucesso");


        }

        ///
        /// <summary>
        /// 	Retorna os restaurantes cadastrados na enquete
        /// </summary>
        ///
        [HttpGet]
        [Route("enquetes/{idEnquete}/restaurantes")]
        public IEnumerable<RestauranteRetorno> GetRestaurantesEnquete(int idEnquete)
        {
            this.enqueteService = new EnqueteService();
            var restaurantes = enqueteService.GetRestaurantesEnquete(idEnquete);
            return restaurantes;
        }

        ///
        /// <summary>
        /// 	Encerra a Enquete e traz de volta o vencedor
        /// </summary>
        ///
        [HttpPut]
        [Route("enquetes/{idEnquete}/encerrar")]
        public IHttpActionResult encerrarEnquete(int idEnquete)
        {
            this.enqueteService = new EnqueteService();
            var retorno = this.enqueteService.encerrarEnquete(idEnquete);
            if (retorno == null)
            {
                return Content(HttpStatusCode.BadRequest, "Não foi possivel gerar o vencedor dessa enquete");
            }
            return Content(HttpStatusCode.OK, "Restaurante " + retorno.FirstOrDefault().restauranteNome + " foi o vencedor da enquete com "+ retorno.FirstOrDefault().restauranteVotos);
        }

        /*
        ///
        /// <summary>
        /// 	Encerra a Enquete sorteando o vencedor
        /// </summary>
        ///
        [HttpGet]
        [Route("enquetes/{idEnquete}/sortear")]
        public IHttpActionResult sortearEnquete(int idEnquete)
        {
            this.enqueteService = new EnqueteService();
            var retorno = this.enqueteService.sortearEnquete(idEnquete);
            if (retorno == null)
            {
                return Content(HttpStatusCode.BadRequest, "Não foi possivel gerar o vencedor dessa enquete");
            }
            return Content(HttpStatusCode.OK, "Restaurante " + retorno+ " foi o vencedor da enquete ");
        }
        */

    }
}