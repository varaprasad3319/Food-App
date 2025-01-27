using FoodBooking4.Data;
using FoodBooking4.Models;
using FoodBooking4.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FoodBooking4.RepoServices
{
    public class ListOfComboItemsRepo : IListOfComboItems
    {
        private readonly ApplicationDbContext _dbContext;
        public ListOfComboItemsRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddIteminComboAsync(ListOfComboItems listOfComboItems)
        {
            await _dbContext.listOfComboItems.AddAsync(listOfComboItems);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ListOfComboItems>> GetAllIteminCombo()
        {
            return await _dbContext.listOfComboItems.ToListAsync();
        }

        public async Task RemoveIteminComboAsync(int id)
        {
            var result = await _dbContext.listOfComboItems.FirstOrDefaultAsync(x => x.Item_Id == id);

            if (result != null)
            {
                _dbContext.listOfComboItems.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateIteminComboAsync( ListOfComboItems listOfComboItems)
        {
            //var result = await _dbContext.listOfComboItems.FirstOrDefaultAsync(x => x.Item_Id == id);

            //if (result != null)
            //{
            //    result.Item_Name = listOfComboItems.Item_Name;
            //    result.Item_Price = listOfComboItems.Item_Price;
            //    result.Combo_Id = listOfComboItems.Combo_Id;
            //    await _dbContext.SaveChangesAsync();
            //}
            _dbContext.Entry(listOfComboItems).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
       
    }
}
