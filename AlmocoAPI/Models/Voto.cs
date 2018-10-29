using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Models
{
    public class Voto
    {
        public int votoId;
        public Voto()
        {
            this.Restaurantes = new HashSet<Restaurante>();
        }
        public Grupo Grupo { get; set; }
        public virtual ICollection<Restaurante> Restaurantes { get; set; }
    }
   
}