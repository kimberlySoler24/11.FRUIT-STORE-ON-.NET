using System.Text.Json;
using TiendaDeFrutas.Contracts;
using TiendaDeFrutas.Dto;
using TiendaDeFrutas.Entities;
using TiendaDeFrutas.Repository;


namespace TiendaDeFrutas.Services.Contracts.impl
{
    public class OrderService : IOrderService
    {
        private readonly IFruitRepository _fruitRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IFruitRepository fruitRepository, IOrderRepository orderRepository)
        {
            _fruitRepository = fruitRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Order> CreateOrder(List<OrderDto> listOrderDto)
        {
            List<Fruit> listFruit = await _fruitRepository.GetAllFruits();

            double totalValue = 0;
            int totalOrderFruits = 0;
            int sizeListOrder = listOrderDto.Count;

            foreach (var order in listOrderDto)
            {
                int countInt = 0;
                var fruitOrder = order.type;
                var quantityOrder = order.quantity;
                foreach (var fruit in listFruit)
                {
                    var fruitItem = fruit.type;
                    var quantityFruit = fruit.quantity;
                    var priceFruit = fruit.price;
                    double semiTotal = 0;

                    if (fruitOrder.Equals(fruitItem))
                    {
                        countInt++;
                    }

                    if (fruitOrder.Equals(fruitItem) && quantityOrder <= quantityFruit)
                    {
                        totalOrderFruits = quantityOrder + totalOrderFruits;
                        if (quantityOrder >= 10)
                        {
                            double percentage = 10 * 0.05;
                            semiTotal = (priceFruit*10) - priceFruit * percentage;
                        }
                        else
                        {
                            semiTotal = priceFruit * quantityOrder;
                        }

                        totalValue = semiTotal + totalValue;

                    }
                    else if (fruitOrder.Equals(fruitItem) && quantityOrder > quantityFruit)
                    {
                        throw new Exception("Your quantity: " + quantityOrder +
                            "request fruit is exceed the quantity we have: " + quantityFruit + ":( !!");
                    }

                }

                if (countInt == 0)
                {
                    throw new Exception("We don`t have: " + fruitOrder); 
                }
 
            }

            if (sizeListOrder >= 5)
            {
                totalValue = totalValue - (totalValue * 0.1);
            }

            //change from object to json to save entitie Order
            string json = JsonSerializer.Serialize(listOrderDto);

            Order createOrder = new Order 
            { 
                fruit_list = json,
                total_value = totalValue,
                created_date = DateTime.Now,
                updated_date = DateTime.Now,
            };

            var finalResult = await _orderRepository.Create(createOrder);

            return finalResult;
           
        }
    }
}
