using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Models
{
    public class UsuarioCadastro
    {
        public long UsuarioCpf { get; set; }

        public string UsuarioNome { get; set; }

        public double UsuarioSaldo { get; set; }

        public string UsuarioEmail { get; set; }

    }
}