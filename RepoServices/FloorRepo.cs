using FoodBooking4.Data;
using FoodBooking4.Models;
using FoodBooking4.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodBooking4.RepoServices
{
    public class FloorRepo : IFloor
    {
        private readonly ApplicationDbContext _dbContext;
        public FloorRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddFloorsAsync(Floor floor)
        {
            await _dbContext.floors.AddAsync(floor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Floor>> GetAllFloors()
        {
            return await _dbContext.floors.ToListAsync();
        }

        public async Task RemoveFloorsAsync(int id)
        {
            var result = await _dbContext.floors.FirstOrDefaultAsync(x => x.Floorr_Id == id);

            if (result != null)
            {
                _dbContext.floors.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateFloorsAsync(Floor floor)
        {
            //var result = await _dbContext.floors.FirstOrDefaultAsync(x => x.Floorr_Id == id);

            //if (result != null)
            //{
            //    result.Floor_Name = floor.Floor_Name;
            //    result.FC_Id = floor.FC_Id;
            //    await _dbContext.SaveChangesAsync();
            //}
            _dbContext.Entry(floor).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
