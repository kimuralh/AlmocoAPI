using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Models
{
    public class UsuarioCadastro
    {
        public long usuarioCpf { get; set; }

        public string usuarioNome { get; set; }

        public double usuarioSaldo { get; set; }

        public string usuarioEmail { get; set; }

        public string usuarioSenha { get; set; }

        public UsuarioCadastro()
        {

        }

        public UsuarioCadastro(Usuario usuario)
        {
           
            this.usuarioCpf = usuario.UsuarioCpf;
            this.usuarioNome = usuario.UsuarioNome;
            this.usuarioSaldo = usuario.UsuarioSaldo;
            this.usuarioEmail = usuario.UsuarioEmail;
            this.usuarioSenha = usuario.UsuarioSenha;
        }
        
    }
}