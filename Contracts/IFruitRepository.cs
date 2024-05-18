using TiendaDeFrutas.Dto;
using TiendaDeFrutas.Entities;

namespace TiendaDeFrutas.Contracts
{
    public interface IFruitRepository
    {
        public Task<Fruit> create(Fruit fruit);

        public Task<Fruit?> GetFruit(int id);

        public Task Delete(int id);

        public Task<List<Fruit>> GetAllFruits();

        public Task<Fruit?> UpdateFruit(UpdateFruitDto updateFruit);
    }
}
