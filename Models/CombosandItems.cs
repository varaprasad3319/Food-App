using System.ComponentModel.DataAnnotations;

namespace FoodBooking4.Models
{
    public class CombosandItems
    {
        [Key]
        public int Combo_Id { get; set; }
        public int Floor_Id {  get; set; }
        public int Res_Id {  get; set; }
        public string Combo_Name { get; set; }
        public int Combo_Price {  get; set; }
    }
}
