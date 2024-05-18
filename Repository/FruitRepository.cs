using Microsoft.EntityFrameworkCore;
using TiendaDeFrutas.Contracts;
using TiendaDeFrutas.Data;
using TiendaDeFrutas.Dto;
using TiendaDeFrutas.Entities;

namespace TiendaDeFrutas.Repository
{
    public class FruitRepository : IFruitRepository
    {
        private readonly DataContext _context;

        public FruitRepository(DataContext context) => _context = context;

        public async Task<Fruit> create(Fruit fruit)
        {
            _context.Fruits.Add(fruit);
            await _context.SaveChangesAsync();

            return fruit;
        }

        public async Task<Fruit?> GetFruit(int id)
        {
            var fruit = await _context.Fruits.FindAsync(id);

            return fruit;
        }


        public async Task Delete(int id)
        {
            var delete = await _context.Fruits.FindAsync(id);
            _context.Fruits.Remove(delete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Fruit>> GetAllFruits()
        {
            var fruits = await _context.Fruits.ToListAsync();

            return fruits;
        }

        public async Task<Fruit?> UpdateFruit(UpdateFruitDto updateFruit)
        {
            var update = await _context.Fruits.FindAsync(updateFruit.Id);
            update.type = updateFruit.type;
            update.quantity = updateFruit.quantity;
            update.price = updateFruit.price;
            update.updated_date = DateTime.Now;

            await _context.SaveChangesAsync();

            return update;
        }
    }
}
