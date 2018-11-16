using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlmocoAPI.Models;
using AlmocoAPI.Repositories.Implementation;

namespace AlmocoAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AlmocoAPIContext _context;

        public UnitOfWork(AlmocoAPIContext context)
        {
            _context = context;
            Usuarios = new UsuarioRepository(_context);
            Restaurantes = new RestauranteRepository(_context);
            Votos = new VotoRepository(_context);
            Grupos = new GrupoRepository(_context);
            Enquetes = new EnqueteRepository(_context);

        }
        
        public IUsuarioRepository Usuarios { get; private set; }

        public IRestauranteRepository Restaurantes { get; private set; }

        public IVotoRepository Votos { get; private set; }

        public IGrupoRepository Grupos { get; private set; }

        public IEnqueteRepository Enquetes { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}