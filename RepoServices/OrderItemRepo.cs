using FoodBooking4.Data;
using FoodBooking4.Models;
using FoodBooking4.Models.LoginDto;
using FoodBooking4.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodBooking4.RepoServices
{
    public class OrderItemRepo : IOrderItem
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderItemRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddOrderItemAsync(OrderItemDto orderItem)
        {
            var res = _dbContext.CombosandItems.FirstOrDefault(r => r.Combo_Id == orderItem.ComboId);

            var Order = new OrderItem()
            {
                OrderId = orderItem.OrderId,
                Price = res.Combo_Price,
                Quantity = orderItem.Quantity,
                ComboId = orderItem.ComboId
            };
            await _dbContext.orderItems.AddAsync(Order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItems()
        {
            return await _dbContext.orderItems.ToListAsync();
        }

        public async Task RemoveOrderItemAsync(int id)
        {
            var result = await _dbContext.orderItems.FirstOrDefaultAsync(x => x.OrderItemId == id);

            if (result != null)
            {
                _dbContext.orderItems.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        //public async Task UpdateOrderItemAsync(int id, OrderItem orderItem)
        //{
        //    var result = await _dbContext.orderItems.FirstOrDefaultAsync(x => x.OrderItemId == id);

        //    if (result != null)
        //    {
        //        result.OrderId = orderItem.OrderId;
        //        result.ItemId = orderItem.ItemId;
        //        result.Price = orderItem.Price;
        //        result.Quantity = orderItem.Quantity;
        //        await _dbContext.SaveChangesAsync();
        //    }
        //}
        //_dbContext.Entry(combosandItems).State = EntityState.Modified;
        //    _dbContext.SaveChanges();
    }
}
