using System.ComponentModel.DataAnnotations;

namespace FoodBooking4.Models.NewFolder
{
    public class RegisterUser
    {
        [Key]
        public int User_Id { get; set; }
        public string Emp_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
