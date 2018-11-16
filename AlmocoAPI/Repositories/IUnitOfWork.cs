using AlmocoAPI.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get;}

        IRestauranteRepository Restaurantes { get; }

        IVotoRepository Votos { get; }

        IGrupoRepository Grupos { get;}

        IEnqueteRepository Enquetes { get;}

        int Complete();
    }
}