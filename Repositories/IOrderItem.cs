using FoodBooking4.Models;
using FoodBooking4.Models.LoginDto;

namespace FoodBooking4.Repositories
{
    public interface IOrderItem
    {
         Task AddOrderItemAsync(OrderItemDto orderItem);
         Task RemoveOrderItemAsync(int orderitem_id);

         Task<IEnumerable<OrderItem>> GetAllOrderItems();
    }
}
