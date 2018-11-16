using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlmocoAPI.Models
{
    public class Restaurante
    {
        [Key]
        public int RestauranteId { get; set; }

        [Required]
        public string RestauranteNome { get; set; }

        public int VezesFrequentado { get; set; }

        public double PrecoTotal { get; set; }

        public double PrecoMedio { get; set; }

        public Grupo Grupo { get; set; }

        public virtual ICollection<Enquete> Enquetes { get; set; }


    }
}