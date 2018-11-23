using AlmocoAPI.DTO;
using AlmocoAPI.Models;
using AlmocoAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmocoAPI.Domain
{
    public class RestauranteService
    {
        //public Resposta RegistraVisita(Restaurante restaurante, float precoRefeicao?)
        UnitOfWork unitOfWork = new UnitOfWork(new AlmocoAPIContext());
        public IEnumerable<Restaurante> GetRestaurantes()
        {
            return unitOfWork.Restaurantes.GetAll();
        }
        public Restaurante PostRestaurante(RestauranteCadastro restauranteCadastro)
        {
            var restauranteBanco = unitOfWork.Restaurantes.Find(x => x.RestauranteNome == restauranteCadastro.restauranteNome);
            if (restauranteBanco.Count() > 0)
            {
                Restaurante restauranteNull = null;
                return restauranteNull;
            }

            else
            {
                Restaurante restaurante = new Restaurante()
                {
                    RestauranteNome = restauranteCadastro.restauranteNome,
                    VezesFrequentado = restauranteCadastro.vezesFrequentado,
                    PrecoTotal = restauranteCadastro.precoTotal,
                    PrecoMedio = restauranteCadastro.precoMedio
                };
                unitOfWork.Restaurantes.Add(restaurante);
                
                unitOfWork.Complete();

                return restaurante;
            }
        }
    }
}