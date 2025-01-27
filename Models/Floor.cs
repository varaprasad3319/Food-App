using System.ComponentModel.DataAnnotations;

namespace FoodBooking4.Models
{
    public class Floor
    {
        [Key]
        public int Floorr_Id { get; set; }
        public int FC_Id {  get; set; }
       
        public string Floor_Name { get; set; }
    }
}
