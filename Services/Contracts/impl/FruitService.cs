using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaDeFrutas.Contracts;
using TiendaDeFrutas.Data;
using TiendaDeFrutas.Dto;
using TiendaDeFrutas.Entities;
using TiendaDeFrutas.Services.Contracts;

namespace TiendaDeFrutas.Services.Contracts.impl
{
    public class FruitService : IFruitService
    {
        private readonly IFruitRepository _fruitRepository;
       
        public FruitService(IFruitRepository fruitRepository)
        {
            _fruitRepository = fruitRepository;
        }

        public async Task<Fruit> AddFruit(Fruit fruit)
        {
           var createFruit = await _fruitRepository.create(fruit);

            return createFruit;

        }

        public async Task<Fruit?> GetFruit(int id)
        {
            var fruitById = await _fruitRepository.GetFruit(id);

            return fruitById;
        }

        public async Task<string?> DeleteFruit(int id)
        {
            var fruitById = await _fruitRepository.GetFruit(id);

            if (fruitById is null)
            {
                return null;
            }

            await _fruitRepository.Delete(id);


            return "Delete successfuly!!";
        }

        public async Task<List<Fruit>> GetAllFruits()
        {
            var list = await _fruitRepository.GetAllFruits();
            return list;
        }

        public async Task<Fruit?> UpdateFruit(UpdateFruitDto updateFruit)
        {
            var fruitById = await _fruitRepository.GetFruit(updateFruit.Id);

            if (fruitById is null)
            {
                return null;
            }

            var update = await _fruitRepository.UpdateFruit(updateFruit);

            return update;
        }
    }
}
