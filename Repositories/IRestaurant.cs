using FoodBooking4.Models;

namespace FoodBooking4.Repositories
{
    public interface IRestaurant
    {
         Task AddResAsync(Restaurant restaurant);
         Task RemoveResAsync(int Res_Id);

         Task UpdateResAsync( Restaurant restaurant);

         Task<IEnumerable<Restaurant>> GetAllRes();
    }
}
