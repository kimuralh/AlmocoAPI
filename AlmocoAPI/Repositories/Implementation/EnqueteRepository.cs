using AlmocoAPI.DTO;
using AlmocoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Repositories.Implementation
{
    public class EnqueteRepository : Repository<Enquete>, IEnqueteRepository
    {
        AlmocoAPIContext context = new AlmocoAPIContext();
        public EnqueteRepository(AlmocoAPIContext context) : base(context)
        {
        }

        public IEnumerable<VotosQuantidade> encerrarEnquete(int idEnquete)
        {
            /*
            try
            {
                */
            var votos = (from v in context.Votos
                         where v.Enquete.EnqueteId == idEnquete
                         select new VotoSimples()
                         {
                             votoId = v.VotoId,
                             usuarioNome = v.Usuario.UsuarioNome,
                             restauranteNome = v.Restaurante.RestauranteNome,
                             enqueteId = v.VotoId
                         }).ToList();
            

            
            var votoCount = votos.GroupBy(x => x.restauranteNome)
                                    .Select(x => new VotosQuantidade() { restauranteNome = x.Key, restauranteVotos = x.Count() }).ToList();

                var votoCountOrdenado = (from v in votoCount
                                         orderby v.restauranteVotos descending
                                         select v).ToList();

                return votoCountOrdenado;
            /*
            }
            catch
            {
         
                List<VotosQuantidade> votoNullLista = null;
                return votoNullLista;
            }
            */
            

        }

        public IEnumerable<EnqueteRetorno> GetPaginaEnquetes(int idGrupo, int pagina, int tamanhoPagina)
        {
            var paginaEnquetes = (from e in context.Enquetes
                                  where e.Grupo.GrupoId == idGrupo
                                  orderby e.EnqueteId descending
                                  select new EnqueteRetorno()
                                  {
                                      EnqueteId = e.EnqueteId,
                                      GrupoId = e.Grupo.GrupoId,
                                      Status = e.Status     
                                  }
                                  ).Skip(pagina*10).Take(tamanhoPagina);
            return paginaEnquetes;
        }

        public IEnumerable<RestauranteRetorno> GetRestaurantesEnquete(int idEnquete)
        {
            var enquete = (from e in context.Enquetes
                           where e.EnqueteId == idEnquete
                           select e).FirstOrDefault();
            var restaurantes = (from r in enquete.Restaurantes
                                select new RestauranteRetorno()
                                {
                                    RestauranteId = r.RestauranteId,
                                    RestauranteNome = r.RestauranteNome
                                }).ToList();
            return restaurantes;
        }

        public bool VerificaPertenceMesmoGrupo(int idEnquete, int idRestaurante)
        {

            var cruzar = (from e in context.Enquetes
                           join r in context.Restaurantes
                           on e.Grupo.GrupoId equals r.Grupo.GrupoId
                           where e.EnqueteId == idEnquete && r.RestauranteId == idRestaurante
                          select e).ToList();
           
            if (cruzar.Count()>0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}




