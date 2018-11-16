using AlmocoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Repositories.Implementation
{
    public class VotoRepository : Repository<Voto>, IVotoRepository
    {
        public VotoRepository(AlmocoAPIContext context) : base(context)
        {
        }
    }
}