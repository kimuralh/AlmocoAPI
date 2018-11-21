using AlmocoAPI.DTO;
using AlmocoAPI.Models;
using AlmocoAPI.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Repositories.Implementation
{
    public interface IVotoRepository : IRepository<Voto>
    {
        IEnumerable<VotoSimples> GetVotos();
        VotoSimples GetVoto(int idVoto);
        IEnumerable<VotoSimples> GetVotosUsuario(int idUsuario);
        Boolean VerificaVotouGrupo(int idEnquete, int usuarioId);
        Boolean PutVoto(VotoAlterado voto);
    }
}