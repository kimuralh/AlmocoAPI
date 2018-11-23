using AlmocoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.DTO
{
    public class GrupoDetalhe
    {
        public int GrupoId { get; set; }
        public string GrupoNome { get; set; }

        public ICollection<UsuarioComId> Membros { get; set; }

        public ICollection<RestauranteRetorno> Restaurantes { get; set; }

        public ICollection<EnqueteRetorno> Enquetes { get; set; }
    }
}