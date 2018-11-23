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
    public class RestaurantesController : ApiController
    {
        private AlmocoAPIContext db = new AlmocoAPIContext();
        private RestauranteService restauranteService;
        // GET: api/Restaurantes
        [HttpGet]
        [Route("restaurantes/")]
        public IEnumerable<Restaurante> GetRestaurantes()
        {
            this.restauranteService = new RestauranteService();

            return this.restauranteService.GetRestaurantes();

        }

        // GET: api/Restaurantes/5
        [ResponseType(typeof(Restaurante))]
        public IHttpActionResult GetRestaurante(int id)
        {
            Restaurante restaurante = db.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            return Ok(restaurante);
        }

        // PUT: api/Restaurantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestaurante(int id, Restaurante restaurante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != restaurante.RestauranteId)
            {
                return BadRequest();
            }

            db.Entry(restaurante).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestauranteExists(id))
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

        ///
        /// <summary>
        /// 	Registra um restaurante
        /// </summary>
        ///
        // POST: api/restaurante
        [HttpPost]
        [Route("restaurantes/")]
  
        public IHttpActionResult PostRestaurante([FromBody] RestauranteCadastro restaurante)  
        {
            this.restauranteService = new RestauranteService();
            var retorno = this.restauranteService.PostRestaurante(restaurante);
            if (retorno == null)
            {
                return Content(HttpStatusCode.BadRequest, "Não foi possivel cadastrar esse restaurante");
            }
            return Content(HttpStatusCode.OK, "Restaurante " + retorno.RestauranteNome + " foi cadastrado com sucesso");
        }

        // DELETE: api/Restaurantes/5
        [ResponseType(typeof(Restaurante))]
        public IHttpActionResult DeleteRestaurante(int id)
        {
            Restaurante restaurante = db.Restaurantes.Find(id);
            if (restaurante == null)
            {
                return NotFound();
            }

            db.Restaurantes.Remove(restaurante);
            db.SaveChanges();

            return Ok(restaurante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RestauranteExists(int id)
        {
            return db.Restaurantes.Count(e => e.RestauranteId == id) > 0;
        }
    }
}