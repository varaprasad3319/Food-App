using System.ComponentModel.DataAnnotations;

namespace FoodBooking4.Models.LoginDto
{
    public class OrdersDto
    {
        [Key]
        public int OrderId { get; set; }
        public int EmpId { get; set; }
        public DateTime OrderDate { get; set; }
        //public decimal TotalAmount { get; set; }
    }
}
