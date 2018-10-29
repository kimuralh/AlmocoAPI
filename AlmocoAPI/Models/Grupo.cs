using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Models
{
    public class Grupo
    {
        
        public Grupo()
        {
            this.Membros = new HashSet<Usuario>();
            this.Restaurantes = new HashSet<Restaurante>();
        }


        public long GrupoId { get; set; }
        public string GrupoNome { get; set; }

        public virtual ICollection<Usuario> Membros { get; set; }
        public virtual ICollection<Restaurante> Restaurantes { get; set; }
    }
}