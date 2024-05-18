using TiendaDeFrutas.Entities;

namespace TiendaDeFrutas.Contracts
{
    public interface IOrderRepository
    {
        public Task<Order> Create(Order order);
    }
}
