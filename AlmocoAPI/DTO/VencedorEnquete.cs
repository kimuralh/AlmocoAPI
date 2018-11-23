using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.DTO
{
    public class VencedorEnquete
    {
        public int idGrupo { get; set; }

        public string nomeGrupo { get; set; }

        public int quantidadeVotos { get; set; }

        public VencedorEnquete()
        {

        }
    }
}