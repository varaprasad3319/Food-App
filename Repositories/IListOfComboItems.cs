using FoodBooking4.Models;

namespace FoodBooking4.Repositories
{
    public interface IListOfComboItems
    {
         Task AddIteminComboAsync(ListOfComboItems listOfComboItems);
         Task RemoveIteminComboAsync(int Item_Id);

        Task UpdateIteminComboAsync(ListOfComboItems listOfComboItems);

         Task<IEnumerable<ListOfComboItems>> GetAllIteminCombo();
    }
}
