using FoodBooking4.Authentication;
using FoodBooking4.Models;
using FoodBooking4.Models.NewFolder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace FoodBooking4.Data
{
    public class ApplicationDbContext: IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }//template

        public DbSet<CombosandItems> CombosandItems { get; set; }//converts class to tables
  
        public DbSet<Floor> floors { get; set; }
        public DbSet<FoodCourt> foodCourt { get; set; }
        public DbSet<ListOfComboItems> listOfComboItems { get; set; } 
        public DbSet<Restaurant> restaurants { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<RegisterAdmin>registerAdmins { get; set; }
        public DbSet<RegisterUser> registerUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OrderItem>()
                .Property(c => c.Price)
                .HasColumnType("decimal(18,2)");
            builder.Entity<Orders>()
                .Property(c => c.TotalAmount)
                .HasColumnType("decimal(18,2)");

        }
    }
}
