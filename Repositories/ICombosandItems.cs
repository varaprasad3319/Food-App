using FoodBooking4.Models;

namespace FoodBooking4.Repositories
{
    public interface ICombosandItems
    {
         Task AddComboorItemAsync(CombosandItems combosandItems);
         Task RemoveComboorItemAsync(int Combo_Id);

         Task UpdateComboorItemAsync(CombosandItems combosandItems);

         Task<IEnumerable<CombosandItems>> GetAllComboorItem();
         Task<IEnumerable<ListOfComboItems>> GetAllComboListItemsById(int id);
    }
}
