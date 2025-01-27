using System.ComponentModel.DataAnnotations;

namespace FoodBooking4.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ComboId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //public string Combo_Name { get; set; }
    }
}