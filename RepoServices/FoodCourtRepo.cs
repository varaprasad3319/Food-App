using FoodBooking4.Data;
using FoodBooking4.Models;
using FoodBooking4.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodBooking4.RepoServices
{
    public class FoodCourtRepo: IFoodCourt
    {
        private readonly ApplicationDbContext _dbContext;
        public FoodCourtRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddFoodCourtAsync(FoodCourt foodCourt)
        {
            await _dbContext.foodCourt.AddAsync(foodCourt);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<FoodCourt>> GetAllFoodCourts()
        {
            return await _dbContext.foodCourt.ToListAsync();
        }

        public async Task RemoveFoodCourtAsync(int id)
        {
            var result = await _dbContext.foodCourt.FirstOrDefaultAsync(x => x.FC_Id == id);

            if (result != null)
            {
                _dbContext.foodCourt.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateFoodCourtAsync( FoodCourt foodCourt)
        {
            //var result = await _dbContext.foodCourt.FirstOrDefaultAsync(x => x.FC_Id == id);

            //if (result != null)
            //{
            //    result.FC_Name = foodCourt.FC_Name;
            //    result.Location = foodCourt.Location; 

            //    await _dbContext.SaveChangesAsync();
            //}
            _dbContext.Entry(foodCourt).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

       
    }
}
