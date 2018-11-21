using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Models
{
    public class UsuarioComIdComGrupo
    {
        public int usuarioId { get; set; }

        public long usuarioCpf { get; set; }

        public string usuarioNome { get; set; }

        public double usuarioSaldo { get; set; }

        public string usuarioEmail { get; set; }

        public virtual IEnumerable<GrupoRetorno> grupos { get; set; }

        public UsuarioComIdComGrupo(Usuario usuario)
        {
            this.usuarioId = usuario.UsuarioId;
            this.usuarioCpf = usuario.UsuarioCpf;
            this.usuarioNome = usuario.UsuarioNome;
            this.usuarioSaldo = usuario.UsuarioSaldo;
            this.usuarioEmail = usuario.UsuarioEmail;
            var grupos = from u in usuario.Grupos

                         select new GrupoRetorno(u);
            this.grupos = grupos;
        }
        public UsuarioComIdComGrupo()
        {

        }
      
    }
}