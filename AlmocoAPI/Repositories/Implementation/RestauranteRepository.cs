using AlmocoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Repositories.Implementation
{
    public class RestauranteRepository : Repository<Restaurante>, IRestauranteRepository
    {
        AlmocoAPIContext context = new AlmocoAPIContext();
        public RestauranteRepository(AlmocoAPIContext context) : base(context)
        {
        }
    }
}