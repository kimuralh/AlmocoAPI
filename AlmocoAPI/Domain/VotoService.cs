using AlmocoAPI.DTO;
using AlmocoAPI.Models;
using AlmocoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AlmocoAPI.Domain
{
    public class VotoService
    {
        /*
        public Resposta RegistraVoto(Voto voto)
        {
            //chama autentica voto
            //verificar se ele esta votando em uma enquete ativa
            //e se ele esta no grupo que ele quer registrar o voto
        }
        */
        UnitOfWork unitOfWork = new UnitOfWork(new AlmocoAPIContext());

        public IEnumerable<VotoSimples> GetVotos()
        {
            var votos = unitOfWork.Votos.GetVotos();

            //select new VotoSimples(u);

            unitOfWork.Complete();
            return votos;
        }

        public VotoSimples GetVoto(int idVoto)
        {
            var voto = unitOfWork.Votos.GetVoto(idVoto);

            //select new VotoSimples(u);

            unitOfWork.Complete();
            return voto;
        }

        public IEnumerable<VotoSimples> GetVotosUsuario(int idUsuario)
        {
            var votos = unitOfWork.Votos.GetVotosUsuario(idUsuario);
            unitOfWork.Complete();
            return votos;

        }

        internal Boolean PostVoto(VotoCadastro voto)
        {
            /*
            public int usuarioId { get; set; }

        public int restauranteId { get; set; }

        public int enqueteId { get; set; }
        */

            var votoBanco = unitOfWork.Votos.VerificaVotouGrupo(voto.enqueteId, voto.usuarioId);
            if (votoBanco == true)
            {

                return false;
            }

            else
            {

                Voto votoDefault = new Voto()
                {

                    Usuario = unitOfWork.Usuarios.Find(x => x.UsuarioId == voto.usuarioId).FirstOrDefault(),
                    Restaurante = unitOfWork.Restaurantes.Find(x => x.RestauranteId == voto.restauranteId).FirstOrDefault(),
                    Enquete = unitOfWork.Enquetes.Find(x => x.EnqueteId == voto.enqueteId).FirstOrDefault()

                };


                unitOfWork.Votos.Add(votoDefault);
                //var usuarioNovo = unitOfWork.Usuarios.Find(x => x.UsuarioCpf == usuario.UsuarioCpf).FirstOrDefault();
                unitOfWork.Complete();

                //var usuarioComId = new UsuarioComId(usuarioNovo);
                return true;
            }
        }
        public Boolean PutVoto(VotoAlterado voto)
        {
            var votoBanco = unitOfWork.Votos.PutVoto(voto);
            return votoBanco;

        }


    }
}
