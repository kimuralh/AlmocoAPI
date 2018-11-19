using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Models
{
    public class UsuarioComIdComGrupo
    {
        public int UsuarioId { get; set; }

        public long UsuarioCpf { get; set; }

        public string UsuarioNome { get; set; }

        public double UsuarioSaldo { get; set; }

        public string UsuarioEmail { get; set; }

        public virtual IEnumerable<GrupoRetorno> Grupos { get; set; }

        public UsuarioComIdComGrupo(Usuario usuario)
        {
            UsuarioId = usuario.UsuarioId;
            UsuarioCpf = usuario.UsuarioCpf;
            UsuarioNome = usuario.UsuarioNome;
            UsuarioSaldo = usuario.UsuarioSaldo;
            UsuarioEmail = usuario.UsuarioEmail;
            var grupos = from u in usuario.Grupos

                         select new GrupoRetorno(u);
            Grupos = grupos;
        }
        public UsuarioComIdComGrupo()
        {

        }
      
    }
}