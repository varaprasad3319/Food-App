using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodBooking4.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public int EmpId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}