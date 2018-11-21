using AlmocoAPI.DTO;
using AlmocoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Repositories.Implementation
{
    public class VotoRepository : Repository<Voto>, IVotoRepository
    {
        AlmocoAPIContext context = new AlmocoAPIContext();

        public VotoRepository(AlmocoAPIContext context) : base(context)
        {


        }

        public IEnumerable<VotoSimples> GetVotos()
        {

            var votos = (from v in context.Votos
                         join u in context.Usuarios
                         on v.Usuario.UsuarioId equals u.UsuarioId
                         join e in context.Enquetes
                         on v.Enquete.EnqueteId equals e.EnqueteId
                         join r in context.Restaurantes
                          on v.Restaurante.RestauranteId equals r.RestauranteId
                         select new VotoSimples()
                         {
                             votoId = v.VotoId,
                             usuarioNome = u.UsuarioNome,
                             restauranteNome = r.RestauranteNome,
                             enqueteId = e.EnqueteId
                         }).ToList();

            return votos;

        }

        public VotoSimples GetVoto(int idVoto)
        {

            var voto = (from v in context.Votos
                        join u in context.Usuarios
                        on v.Usuario.UsuarioId equals u.UsuarioId
                        join e in context.Enquetes
                        on v.Enquete.EnqueteId equals e.EnqueteId
                        join r in context.Restaurantes
                         on v.Restaurante.RestauranteId equals r.RestauranteId
                        where v.VotoId == idVoto
                        select new VotoSimples()
                        {
                            votoId = v.VotoId,
                            usuarioNome = u.UsuarioNome,
                            restauranteNome = r.RestauranteNome,
                            enqueteId = e.EnqueteId
                        }).FirstOrDefault();

            return voto;

        }
        public IEnumerable<VotoSimples> GetVotosUsuario(int idUsuario)
        {
            var votos = (from v in context.Votos
                         join u in context.Usuarios
                         on v.Usuario.UsuarioId equals u.UsuarioId
                         join e in context.Enquetes
                         on v.Enquete.EnqueteId equals e.EnqueteId
                         join r in context.Restaurantes
                          on v.Restaurante.RestauranteId equals r.RestauranteId
                         where v.Usuario.UsuarioId == idUsuario
                         select new VotoSimples()
                         {
                             votoId = v.VotoId,
                             usuarioNome = u.UsuarioNome,
                             restauranteNome = r.RestauranteNome,
                             enqueteId = e.EnqueteId
                         }).ToList();

            return votos;
        }

        public Boolean VerificaVotouGrupo(int idEnquete, int usuarioId)
        {
            var voto = (from v in context.Votos
                        where (v.Usuario.UsuarioId == usuarioId && v.Enquete.EnqueteId == idEnquete)
                        select v).ToList();
            if (voto.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Boolean PutVoto(VotoAlterado voto)
        {
            var votoDB = (from v in context.Votos
                          where (v.VotoId == voto.votoId)
                          select v).FirstOrDefault();
            if (votoDB == null)
            {
                return false;
            }
            
            
            else
            {
                if (context.Restaurantes.Find(voto.restauranteId) != null)
                {
                    votoDB.Restaurante = context.Restaurantes.Find(voto.restauranteId);
                    context.SaveChanges();
                    return true;
                }
                    
                else
                {
                    return false;
                }
                //pode colocar mais tratamento aqui
            }
            
        }

        
    }
}