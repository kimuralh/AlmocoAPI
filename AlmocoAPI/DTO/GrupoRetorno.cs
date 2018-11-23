using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Models
{
    public class GrupoRetorno
    {
        public int grupoId { get; set; }

        public string grupoNome { get; set; }

        public GrupoRetorno()
        {

        }

        public GrupoRetorno(Grupo grupo)
        {
            this.grupoId = grupo.GrupoId;
            this.grupoNome = grupo.GrupoNome;
        }
    }
}