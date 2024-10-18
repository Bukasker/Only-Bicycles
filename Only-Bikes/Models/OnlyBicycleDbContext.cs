using Microsoft.EntityFrameworkCore;
using Only_bicycles.Models;
using Only_Bikes.Entities;
using Roles = Only_Bikes.Constants.UserRoles;

namespace Only_Bikes.Models;

public class OnlyBicycleDbContext(DbContextOptions<OnlyBicycleDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<GenderCategory> GenderCategories { get; set; }
    public DbSet<Bicycle> Bicycles { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(OnlyBicycleData.Categories);
        modelBuilder.Entity<GenderCategory>().HasData(OnlyBicycleData.GenderCategories);
        modelBuilder.Entity<Bicycle>().HasData(OnlyBicycleData.Bicycles);

        var userRoles = new List<UserRole>
        {
            new()
            {
                Id = Guid.Parse("242b4de4-e0b2-46ed-89a5-f298a1df047f"),
                Name = Roles.Admin
            },
            new()
            {
                Id = Guid.Parse("c9c5347a-1405-47fc-9246-a94be9e32ce7"),
                Name = Roles.User
            }
        };
        modelBuilder.Entity<UserRole>().HasData(userRoles);

        var admin = new User
        {
            Id = Guid.Parse("2301399d-20f9-43cb-8bb4-0dab870bd13a"),
            Name = "Admin",
            PasswordHash = "1aiziBybGL6HHb0Lait3WdoQUQ7JeIlg1QB+rPd3ZBU=",
            PasswordSalt = "CNrViJrDAPgoWmRRehDRjQ==",
            RoleId = userRoles.First(r => r.Name.Equals(Roles.Admin)).Id,
            Role = null
        };
        modelBuilder.Entity<User>().HasData(new List<User>
        {
            admin
        });

        base.OnModelCreating(modelBuilder);
    }
}