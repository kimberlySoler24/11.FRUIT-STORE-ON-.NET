using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TiendaDeFrutas.Entities;

namespace TiendaDeFrutas.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }


        public DbSet<Fruit> Fruits { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
