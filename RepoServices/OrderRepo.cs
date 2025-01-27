using FoodBooking4.Data;
using FoodBooking4.Models;
using FoodBooking4.Models.LoginDto;
using FoodBooking4.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodBooking4.RepoServices
{
    public class OrderRepo : IOrders
    {
        private readonly ApplicationDbContext _dbContext;
        public OrderRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task  AddOrderAsync(OrdersDto orders)
        {
            var res = _dbContext.orderItems.ToList();
            var order = new Orders()
            {
                OrderId = orders.OrderId,
                OrderDate = orders.OrderDate,
                EmpId = orders.EmpId,
                OrderItems = res
            };
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            
        }

        public async Task<List<Orders>> GetAllOrders()
        {
            return await  _dbContext.Orders.ToListAsync();
        }
        public async Task<Orders> GetOrderByOrderId(int id)
        {
            var ress = await _dbContext.Orders.FirstOrDefaultAsync(r => r.OrderId == id);
            if (ress == null)
            {
                return null; // or handle the case where the order is not found
            }

            var res = await _dbContext.orderItems.Where(r => r.OrderId == ress.OrderId).ToListAsync();

            // Fetch the price of each combo item
            foreach (var item in res)
            {
                var comboItem = await _dbContext.CombosandItems.FirstOrDefaultAsync(c => c.Combo_Id == item.ComboId);
                if (comboItem != null)
                {
                    item.Price = comboItem.Combo_Price;
                    //item.Combo_Name = comboItem.Combo_Name;
                }
            }

            decimal totalAmount = res.Sum(item => item.Price * item.Quantity);

            var order = new Orders()
            {
                OrderId = ress.OrderId,
                OrderDate = ress.OrderDate,

                EmpId = ress.EmpId,
                TotalAmount = totalAmount,
                OrderItems = res
            };

            return order;
        }
        public async Task<Orders> AddOrdersAsync(OrdersDto orders)
        {
            var res = _dbContext.orderItems.ToList();
            var order = new Orders()
            {
                OrderDate = orders.OrderDate,
                EmpId = orders.EmpId,
                OrderItems = res
            };
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }
        public async Task RemoveOrderAsync(int id)
        {
            var result = await _dbContext.Orders.FirstOrDefaultAsync(x => x.OrderId == id);

            if (result != null)
            {
                _dbContext.Orders.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
