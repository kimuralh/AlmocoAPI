using AlmocoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Repositories.Implementation
{
    public class GrupoRepository : Repository<Grupo>, IGrupoRepository
    {
        AlmocoAPIContext context = new AlmocoAPIContext();
        public GrupoRepository(AlmocoAPIContext context) : base(context)
        {
        }
        public IEnumerable<UsuarioComId> GetMembrosGrupo(int idGrupo)
        {
            var grupo = (from g in context.Grupos
                        where g.GrupoId == idGrupo
                        select g).FirstOrDefault();
            if(grupo.Membros == null)
            {
                List<UsuarioComId> usuariosLista = null;

                return usuariosLista;
            }
            var usuarios = from u in grupo.Membros
                            select new UsuarioComId()
                            {
                                usuarioId = u.UsuarioId,
                                usuarioNome = u.UsuarioNome,
                                usuarioEmail = u.UsuarioEmail,
                                usuarioSaldo = u.UsuarioSaldo
                            };
            return usuarios;



        }

    }
}