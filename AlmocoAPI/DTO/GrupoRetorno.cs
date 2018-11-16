using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Models
{
    public class GrupoRetorno
    {
        public long GrupoId { get; set; }

        public string GrupoNome { get; set; }

        public GrupoRetorno(Grupo grupo)
        {
            GrupoId = grupo.GrupoId;
            GrupoNome = grupo.GrupoNome;
        }
    }
}