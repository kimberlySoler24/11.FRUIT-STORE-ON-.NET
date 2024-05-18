using TiendaDeFrutas.Dto;
using TiendaDeFrutas.Entities;

namespace TiendaDeFrutas.Services.Contracts
{
    public interface IOrderService
    {
        public Task<Order> CreateOrder(List<OrderDto> listOrderDto);
    }
}
