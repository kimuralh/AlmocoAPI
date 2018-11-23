using AlmocoAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Repositories.Implementation
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        AlmocoAPIContext context = new AlmocoAPIContext();
        public UsuarioRepository(AlmocoAPIContext context) : base(context)
        {
            
        }
    }
}