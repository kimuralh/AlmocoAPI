using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.DTO
{
    public class RestauranteCadastro
    {

        public string restauranteNome { get; set; }

        public int vezesFrequentado { get; set; }

        public double precoTotal { get; set; }

        public double precoMedio { get; set; }

        public RestauranteCadastro()
        {
            this.vezesFrequentado = 0;
            this.precoTotal = 0.0;
            this.precoMedio = 0.0;
        }
    }
}