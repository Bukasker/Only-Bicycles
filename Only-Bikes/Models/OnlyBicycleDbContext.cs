using Microsoft.EntityFrameworkCore;
using Only_bicycles.Models;
using System.IO.Pipelines;

namespace Only_Bikes.Models
{
	public class OnlyBicycleDbContext : DbContext
	{
		public OnlyBicycleDbContext(DbContextOptions<OnlyBicycleDbContext> options) : base(options)
		{

		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<GenderCategory> GenderCategories { get; set; }
		public DbSet<Bicycle> Bicycles { get; set; }
		public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Category>().HasData(OnlyBicycleData.Categories);
            modelBuilder.Entity<GenderCategory>().HasData(OnlyBicycleData.GenderCategories);
            modelBuilder.Entity<Bicycle>().HasData(OnlyBicycleData.Bicycles);

            base.OnModelCreating(modelBuilder);
        }
    }
}
