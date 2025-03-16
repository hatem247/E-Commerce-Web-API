using Holistic_Mission.DTOs.OrderDto;

namespace Holistic_Mission.Repository.OrderRepo
{
    public interface IOrderRepo
    {
        List<OrderResponserDTo> GetOrders(OrderResponserDTo orderDto);
        bool AddOrder (OrderRequstDto orderDto);
        void UpdateOrder (OrderRequstDto orderDto,int id);
        void DeleteOrder (int id);

    }
}
