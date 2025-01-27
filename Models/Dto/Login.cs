using System.ComponentModel.DataAnnotations;

namespace FoodBooking4.Models.LoginDto
{
    public class Login
    {
        public string Emp_Id { get; set; }
        public string Password { get; set; }
    }
}
