using FoodBooking4.Models;

namespace FoodBooking4.Repositories
{
    public interface IFloor
    {
         Task AddFloorsAsync(Floor floor);
        Task RemoveFloorsAsync(int Floor_Id);

        Task UpdateFloorsAsync(Floor floor);

        Task<IEnumerable<Floor>> GetAllFloors();
    }
}
