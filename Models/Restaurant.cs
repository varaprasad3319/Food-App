using System.ComponentModel.DataAnnotations;

namespace FoodBooking4.Models
{
    public class Restaurant
    {
        [Key]
        public int Res_Id { get; set; }
        public int Floor_Id { get; set; }
       
        public string Res_Name { get; set; }
    }
}
