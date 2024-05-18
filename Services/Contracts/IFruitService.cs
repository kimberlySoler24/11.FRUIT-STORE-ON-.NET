using Microsoft.AspNetCore.Mvc;
using TiendaDeFrutas.Dto;
using TiendaDeFrutas.Entities;

namespace TiendaDeFrutas.Services.Contracts
{
    public interface IFruitService
    {
        public Task<List<Fruit>> GetAllFruits();
        public Task<Fruit?> GetFruit(int id);
        public Task<Fruit> AddFruit(Fruit fruit);
        public Task<Fruit?> UpdateFruit(UpdateFruitDto updatefruit);
        public Task<string?> DeleteFruit(int id);
    }
}
