using FoodBooking4.Data;
using FoodBooking4.Models;
using FoodBooking4.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodBooking4.RepoServices
{
    public class RestaurantRepo : IRestaurant
    {
        private readonly ApplicationDbContext _dbContext;
        public RestaurantRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddResAsync(Restaurant restaurant)
        {
            await _dbContext.restaurants.AddAsync(restaurant);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Restaurant>> GetAllRes()
        {
            return await _dbContext.restaurants.ToListAsync();
        }

        public async Task RemoveResAsync(int id)
        {
            var result = await _dbContext.restaurants.FirstOrDefaultAsync(x => x.Res_Id == id);

            if (result != null)
            {
                _dbContext.restaurants.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateResAsync(Restaurant restaurant)
        {
            //var result = await _dbContext.restaurants.FirstOrDefaultAsync(x => x.Res_Id == id);

            //if (result != null)
            //{
            //    result.Res_Name = restaurant.Res_Name;
            //    result.Floor_Id = restaurant.Floor_Id;
            //    await _dbContext.SaveChangesAsync();
            //}
            _dbContext.Entry(restaurant).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
