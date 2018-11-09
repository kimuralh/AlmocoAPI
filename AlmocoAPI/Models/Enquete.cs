using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Models
{
    public class Enquete
    {
        [Key]
        public int EnqueteId { get; set; }  

        public Grupo Grupo { get; set; }

        public virtual ICollection<Restaurante> Restaurantes { get; set; }
        public virtual ICollection<Voto> Votos { get; set; }
        public Restaurante VencedorAtual { get; set; }
        public bool Status { get; set; }
    }
   
}