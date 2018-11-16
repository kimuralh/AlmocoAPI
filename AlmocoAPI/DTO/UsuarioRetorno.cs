﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Models
{
    public class UsuarioRetorno
    {
        public int UsuarioId { get; set; }

        public long UsuarioCpf { get; set; }

        public string UsuarioNome { get; set; }

        public double UsuarioSaldo { get; set; }

        public string UsuarioEmail { get; set; }

        public UsuarioRetorno(Usuario usuario)
        {
            UsuarioId = usuario.UsuarioId;
            UsuarioCpf = usuario.UsuarioCpf;
            UsuarioNome = usuario.UsuarioNome;
            UsuarioSaldo = usuario.UsuarioSaldo;
            UsuarioEmail = usuario.UsuarioEmail;
        }
    }
}