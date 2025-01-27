using System.ComponentModel.DataAnnotations;

namespace FoodBooking4.Models
{
    public class ListOfComboItems
    {
        [Key]
        public int Item_Id { get; set; }
        public int Combo_Id {  get; set; }
       
        public string Item_Name {  get; set; }
        public int Item_Price {  get; set; }
    }
}
