using AlmocoAPI.DTO;
using AlmocoAPI.Models;
using AlmocoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Domain
{
    public class GrupoService
    {
        //public RespostaOk InscreveUsuario(int usuarioId ou string unica);
        //public RespostaOK RemoveUsuario(int usuarioId);
        UnitOfWork unitOfWork = new UnitOfWork(new AlmocoAPIContext());

        public IEnumerable<GrupoRetorno> GetGrupos()
        {

            var grupos = from u in unitOfWork.Grupos.GetAll()
                         select new GrupoRetorno(u);

            unitOfWork.Complete();

            return grupos;

        }

        public Boolean DeleteGrupo(int id)
        {
            Grupo grupo = unitOfWork.Grupos.Find(x => x.GrupoId == id).FirstOrDefault();
            if (grupo == null)
            {
                return false;
            }

            unitOfWork.Grupos.Remove(grupo);
            unitOfWork.Complete();
            return true;
        }

        public Boolean PostCadastroGrupo(GrupoCadastro grupoCadastro)
        {
            Grupo grupo = new Grupo
            {
                GrupoNome = grupoCadastro.grupoNome
            };
            var busca = unitOfWork.Grupos.Find(x => x.GrupoNome == grupoCadastro.grupoNome).FirstOrDefault();
            if (busca == null)
            {
                unitOfWork.Grupos.Add(grupo);
                unitOfWork.Complete();
                return true;
            }
            else
            {
                return false;
            }

        }

        public GrupoRetorno GetGrupo(int idGrupo)
        {
            var grupo = unitOfWork.Grupos.Get(idGrupo);

            if (grupo == null)
            {
                GrupoRetorno grupoComIdNull = null;
                return grupoComIdNull;

            }

            var grupoRetorno = new GrupoRetorno(grupo);
            unitOfWork.Complete();

            return grupoRetorno;
        }

        public IEnumerable<UsuarioComId> GetMembrosGrupo(int idGrupo)
        {
            var usuarios = unitOfWork.Grupos.GetMembrosGrupo(idGrupo);
            return usuarios;
        }

        public Usuario AdicionaMembroGrupo(int idGrupo,int idUsuario)
        {
            var grupo = unitOfWork.Grupos.Get(idGrupo);
            var usuario = unitOfWork.Usuarios.Get(idUsuario);
            if (usuario == null)
            {
                Usuario usuarioNull = null;
                return usuarioNull;
            }
            else
            {
                grupo.Membros.Add(usuario);
                unitOfWork.Complete();
                return usuario;
            }
            
        }
        public Restaurante AdicionaRestauranteGrupo(int idGrupo,  int idRestaurante)
        {
            var grupo = unitOfWork.Grupos.Get(idGrupo);
            var restaurante = unitOfWork.Restaurantes.Get(idRestaurante);
            if (restaurante == null)
            {
                Restaurante restauranteNull = null;
                return restauranteNull;
            }
            else
            {
                grupo.Restaurantes.Add(restaurante);
                unitOfWork.Complete();
                return restaurante;
            }
        }
    }
}