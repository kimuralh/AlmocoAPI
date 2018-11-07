using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Models
{
    public class Grupo
    {
        [Key]
        public long GrupoId { get; set; }

        public string GrupoNome { get; set; }

        public virtual ICollection<Usuario> Membros { get; set; }

        public virtual ICollection<Restaurante> Restaurantes { get; set; }

        public virtual ICollection<Enquete> Enquetes { get; set; }
    }
}