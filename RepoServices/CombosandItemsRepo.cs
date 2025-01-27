using FoodBooking4.Data;
using FoodBooking4.Models;
using FoodBooking4.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace FoodBooking4.RepoServices
{
    public class CombosandItemsRepo : ICombosandItems
    {

        private readonly ApplicationDbContext _dbContext;
        public CombosandItemsRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddComboorItemAsync(CombosandItems combosandItems)
        {
            await _dbContext.CombosandItems.AddAsync(combosandItems);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<CombosandItems>> GetAllComboorItem()
        {
            return await _dbContext.CombosandItems.ToListAsync();
        }

        public async Task RemoveComboorItemAsync(int id)
        {
            var result = await _dbContext.CombosandItems.FirstOrDefaultAsync(x => x.Combo_Id == id);

            if (result != null)
            {
                _dbContext.CombosandItems.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateComboorItemAsync(CombosandItems combosandItems)
        {
            //var result = await _dbContext.CombosandItems.FirstOrDefaultAsync(x => x.Combo_Id == combosandItems.Combo_Id);

            //if (result != null)
            //{
            //    result.Combo_Name = combosandItems.Combo_Name;
            //    result.Combo_Price = combosandItems.Combo_Price;
            //    result.Res_Id = combosandItems.Res_Id;
            //    result.Floor_Id = combosandItems.Floor_Id;

            //    await _dbContext.SaveChangesAsync();
            //}
            _dbContext.Entry(combosandItems).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public async Task<IEnumerable<ListOfComboItems>> GetAllComboListItemsById(int id)
        {
            return await _dbContext.listOfComboItems.Where(x => x.Combo_Id == id).ToListAsync();
        }
    }
}
