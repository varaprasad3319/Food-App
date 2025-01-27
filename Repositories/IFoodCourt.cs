using FoodBooking4.Models;

namespace FoodBooking4.Repositories
{
    public interface IFoodCourt
    {
         Task AddFoodCourtAsync(FoodCourt foodCourt);
         Task RemoveFoodCourtAsync(int FC_Id);

         Task UpdateFoodCourtAsync(FoodCourt foodCourt);

         Task<IEnumerable<FoodCourt>> GetAllFoodCourts();

        
    }
}
