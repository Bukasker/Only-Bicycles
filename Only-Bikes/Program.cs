using Microsoft.EntityFrameworkCore;
using Only_bicycles.Models;
using Only_Bikes.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBicycleRepository, BicycleRepository>();
builder.Services.AddScoped<IGenderCategoryRepository, GenderCategoryRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OnlyBicycleDbContext>(options => {
	options.UseSqlServer(
		builder.Configuration["ConnectionStrings:OnlyBikesContentConnection"]);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseSession();


//app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();





