using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.DTO
{
    public class VotoCadastro
    {
        public int usuarioId { get; set; }

        public int restauranteId { get; set; }

        public int enqueteId { get; set; }

        public VotoCadastro()
        {

        }
        
    }
}