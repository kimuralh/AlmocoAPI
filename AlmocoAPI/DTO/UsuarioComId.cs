using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Models
{
    public class UsuarioComId
    {
        public int usuarioId { get; set; }

        public long usuarioCpf { get; set; }

        public string usuarioNome { get; set; }

        public double usuarioSaldo { get; set; }

        public string usuarioEmail { get; set; }

        public UsuarioComId()
        {

        }

        public UsuarioComId(Usuario usuario)
        {
            this.usuarioId = usuario.UsuarioId;
            this.usuarioCpf = usuario.UsuarioCpf;
            this.usuarioNome = usuario.UsuarioNome;
            this.usuarioSaldo = usuario.UsuarioSaldo;
            this.usuarioEmail = usuario.UsuarioEmail;
        }
    }
}