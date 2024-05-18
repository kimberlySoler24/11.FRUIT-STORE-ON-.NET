using TiendaDeFrutas.Contracts;
using TiendaDeFrutas.Data;
using TiendaDeFrutas.Entities;

namespace TiendaDeFrutas.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly DataContext _dataContext;

        public OrderRepository(DataContext dataContext) => _dataContext = dataContext;

        public async Task<Order> Create(Order order)
        {
            _dataContext.Orders.Add(order);
            await _dataContext.SaveChangesAsync();

            return order;
        }




    }

}
