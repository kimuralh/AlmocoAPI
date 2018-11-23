using AlmocoAPI.DTO;
using AlmocoAPI.Models;
using AlmocoAPI.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Repositories.Implementation
{
    public interface IEnqueteRepository : IRepository<Enquete>
    {
        //Boolean EncerraEnquete(int idEnquete);
        IEnumerable<EnqueteRetorno> GetPaginaEnquetes(int idGrupo, int pagina, int tamanhoPagina);
        Boolean VerificaPertenceMesmoGrupo(int idEnquete, int idRestaurante);
        IEnumerable<RestauranteRetorno> GetRestaurantesEnquete(int idEnquete);
        IEnumerable<VotosQuantidade> encerrarEnquete(int idEnquete);

    }
}