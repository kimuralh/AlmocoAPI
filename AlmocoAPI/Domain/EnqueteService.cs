using AlmocoAPI.DTO;
using AlmocoAPI.Models;
using AlmocoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Domain
{
    public class EnqueteService
    {
        //public Resposta EncerraEnquete(int idEnquete);
        //public Resposta DefineGanhador(Enquete enquete);
        // public Resposta SorteiaGanhador(int idEnquete);
        UnitOfWork unitOfWork = new UnitOfWork(new AlmocoAPIContext());
        public int GetNumeroEnquetes(int idGrupo)
        {
            var numero = unitOfWork.Enquetes.Find(x => x.Grupo.GrupoId == idGrupo).ToList().Count();
            return numero;
        }
        public IEnumerable<EnqueteRetorno> GetPaginaEnquetes(int idGrupo, int pagina, int tamanhoPagina)
        {
            var enquetes = unitOfWork.Enquetes.GetPaginaEnquetes(idGrupo, pagina, tamanhoPagina);
            return enquetes;
        }
        public Enquete PostEnquete(EnqueteCadastro enqueteCadastro)
        {
            var grupo = unitOfWork.Grupos.Get(enqueteCadastro.idGrupo);
            if (grupo == null)
            {
                Enquete enqueteNull = null;
                return enqueteNull;
            }
            else
            {
                Enquete enquete = new Enquete()
                {
                    Status = enqueteCadastro.status,
                    Grupo = grupo
                };
                unitOfWork.Enquetes.Add(enquete);
                unitOfWork.Complete();
                return enquete;
            }
        }
        public IEnumerable<VotosQuantidade> encerrarEnquete(int idEnquete)
        {
            var resultado = unitOfWork.Enquetes.encerrarEnquete(idEnquete);
            if (resultado == null)
            {
                List<VotosQuantidade> votoNullLista = null;
                return votoNullLista;
            }
            else
            {
                unitOfWork.Complete();
                return resultado;
            }

        }
        /*
        public string sortearEnquete(int idEnquete)
        {

        }
        */

        public Restaurante AdicionaRestauranteEnquete(int idEnquete, int idRestaurante)
        {
            var restaurante = unitOfWork.Restaurantes.Get(idRestaurante);
            var enquete = unitOfWork.Enquetes.Get(idEnquete);
            if (enquete == null || restaurante == null)
            {
                Restaurante restauranteNull = null;
                return restauranteNull;
            }
            else
            {
                var verifica = unitOfWork.Enquetes.VerificaPertenceMesmoGrupo(idEnquete, idRestaurante);
                if ( verifica == true)
                {
                    enquete.Restaurantes.Add(restaurante);
                    unitOfWork.Complete();
                    return restaurante;
                }
                else
                {
                    Restaurante restauranteNull = null;
                    return restauranteNull;
                }
            }
            
        }
        public IEnumerable<RestauranteRetorno> GetRestaurantesEnquete(int idEnquete)
        {
            var restaurantes = unitOfWork.Enquetes.GetRestaurantesEnquete(idEnquete);
            return restaurantes;
        }
    }
}