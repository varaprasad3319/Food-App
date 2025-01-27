using System.ComponentModel.DataAnnotations;

namespace FoodBooking4.Models
{
    public class FoodCourt
    {
        [Key]
        public int FC_Id {  get; set; }
        public string FC_Name {  get; set; }
        public string Location {  get; set; }
    }
}
