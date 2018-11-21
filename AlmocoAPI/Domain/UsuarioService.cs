using AlmocoAPI.Models;
using AlmocoAPI.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.Http;
using System.Net.Http;
using System;
using System.Net;

namespace AlmocoAPI.Domain
{
    public class UsuarioService
    {


        UnitOfWork unitOfWork = new UnitOfWork(new AlmocoAPIContext());

        public IEnumerable<UsuarioComId> GetUsuarios()
        {
            var usuarios = from u in unitOfWork.Usuarios.GetAll()

                           select new UsuarioComId(u);

            unitOfWork.Complete();
            return usuarios;
        }

        //-----------------------
        
        public UsuarioComIdComGrupo GetUsuario(int id)
        {
           
            var usuario = unitOfWork.Usuarios.Get(id);
            if (usuario == null)
            {
                return new UsuarioComIdComGrupo();
            }
            //var UsuarioComId = new UsuarioComId(usuario);

            var usuarioComId = new UsuarioComIdComGrupo(usuario);
            unitOfWork.Complete();
            return usuarioComId;

        }

        private bool UsuarioExists(int id)
        {
            if ((unitOfWork.Usuarios.Find(e => e.UsuarioId == id)).Count() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PutUsuario(int usuarioId, UsuarioCadastro usuarioAlterado)
        {
            var usuarioBanco = unitOfWork.Usuarios.Get(usuarioId);
            if (usuarioBanco == null)
            {
                return false;
            }
            
            else if (usuarioId == usuarioBanco.UsuarioId)
            {
                usuarioBanco.UsuarioNome = usuarioAlterado.usuarioNome;
                usuarioBanco.UsuarioCpf = usuarioAlterado.usuarioCpf;
                usuarioBanco.UsuarioEmail = usuarioAlterado.usuarioEmail;
                usuarioBanco.UsuarioSaldo = usuarioAlterado.usuarioSaldo;

                unitOfWork.Complete();
                return true;
            }
            else
            {
                return false;
            }
        }
   
        public Boolean PostUsuario(UsuarioCadastro usuarioCadastrado)
        {
            var usuarioBanco = unitOfWork.Usuarios.Find(x=> x.UsuarioCpf == usuarioCadastrado.usuarioCpf);
            if (usuarioBanco.Count() > 0)
            {
                
                return false;
            }

            else
            {
                Usuario usuario = new Usuario()
                {

                    UsuarioCpf = usuarioCadastrado.usuarioCpf,
                    UsuarioNome = usuarioCadastrado.usuarioNome,
                    UsuarioSaldo = usuarioCadastrado.usuarioSaldo,
                    UsuarioEmail = usuarioCadastrado.usuarioEmail

                };
                unitOfWork.Usuarios.Add(usuario);
                //var usuarioNovo = unitOfWork.Usuarios.Find(x => x.UsuarioCpf == usuario.UsuarioCpf).FirstOrDefault();
                unitOfWork.Complete();

                //var usuarioComId = new UsuarioComId(usuarioNovo);
                return true ;
            }
         


        }
        public Boolean DeleteUsuario(int id)
        {

            Usuario usuario = unitOfWork.Usuarios.Find(x => x.UsuarioId == id).FirstOrDefault();
            if (usuario == null)
            {
                return false;
            }

            unitOfWork.Usuarios.Remove(usuario);
            unitOfWork.Complete();
            return true;
        }

    }
}