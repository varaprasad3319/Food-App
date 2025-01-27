using FoodBooking4.Models;
using FoodBooking4.Models.LoginDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodBooking4.Repositories
{
    public interface IOrders
    {
        Task AddOrderAsync(OrdersDto orders);
        Task RemoveOrderAsync(int order_id);
        Task<List<Orders>> GetAllOrders();
        Task<Orders> GetOrderByOrderId(int id);
        Task<Orders> AddOrdersAsync(OrdersDto orders);
    }
}