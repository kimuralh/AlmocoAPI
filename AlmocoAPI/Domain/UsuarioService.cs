using AlmocoAPI.Models;
using AlmocoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Domain
{
    public class UsuarioService
    {
        UnitOfWork unitOfWork = new UnitOfWork(new AlmocoAPIContext());

        public IEnumerable<UsuarioRetorno> Get()
        {
            var usuarios = from u in unitOfWork.Usuarios.GetAll()

                           select new UsuarioRetorno(u);

            unitOfWork.Complete();
            return usuarios;
        }
        
    }
}