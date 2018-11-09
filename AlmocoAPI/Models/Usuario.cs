using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlmocoAPI.Models
{
    public class Usuario
    {
        
        
        [Key]
        public int UsuarioId { get; set; }

        public long UsuarioCpf { get; set; }

        public string UsuarioNome { get; set; }

        public double UsuarioSaldo { get; set; }

        public string UsuarioEmail { get; set; }

        public virtual ICollection<Grupo> Grupos { get; set; }

        public virtual ICollection<Voto> Votos { get; set; }


    }
}