using AlmocoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.DTO
{
    public class VotoSimples
    {
        public int votoId { get; set; }

        public string usuarioNome { get; set; }

        public string restauranteNome { get; set; }

        public int enqueteId { get; set; }

        public VotoSimples()
        {

        }

        public VotoSimples(Voto voto)
        {
            this.votoId = voto.VotoId;
            this.usuarioNome = voto.Usuario.UsuarioNome;
            this.restauranteNome = voto.Restaurante.RestauranteNome;
            this.enqueteId = voto.VotoId;
        }
    }
}