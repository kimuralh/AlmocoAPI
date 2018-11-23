using AlmocoAPI.Models;
using AlmocoAPI.Repositories.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Repositories.Implementation
{
    public interface IGrupoRepository : IRepository<Grupo>
    {
        IEnumerable<UsuarioComId> GetMembrosGrupo(int idGrupo);

    }
}