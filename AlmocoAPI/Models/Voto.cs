using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlmocoAPI.Models
{
    public class Voto
    {
        [Key]
        public int VotoId { get; set; }

        public Usuario Usuario { get; set; }

        public Restaurante Restaurante { get; set; }


    }
}