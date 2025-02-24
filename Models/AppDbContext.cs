using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChairEcommerce.Models
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole()
            {
                Id = "A1B2C3D4-E5F6-7890-1234-56789ABCDE32",
                Name = "SuperAdmin",
                NormalizedName = "superadmin",
                ConcurrencyStamp = "1234567890ABCDEF"
            },
            new IdentityRole()
            {
                Id = "A1B2C3D4-E5F6-7890-1234-56789ABCDE01",
                Name = "Admin",
                NormalizedName = "admin",
                ConcurrencyStamp = "1234567890ABCDEF"
            },
             new IdentityRole()
             {
                 Id = "B2C3D4E5-F678-9012-3456-789ABCDE0123",
                 Name = "User",
                 NormalizedName = "user",
                 ConcurrencyStamp = "0987654321FEDCBA"
             }
             );
            base.OnModelCreating(builder);
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Address> Addresss { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<TrackingDetails> TrackingDetails { get; set; }
        public DbSet<User> users { get; set; }



    }
}
