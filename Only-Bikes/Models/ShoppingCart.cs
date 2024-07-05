using Only_bicycles.Models;
using System.IO.Pipelines;
using Microsoft.EntityFrameworkCore;
namespace Only_Bikes.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly OnlyBicycleDbContext _onlyBicycleDbContext;
        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        private ShoppingCart(OnlyBicycleDbContext onlyBicycleDbContext)
        {
            _onlyBicycleDbContext = onlyBicycleDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            OnlyBicycleDbContext context = services.GetService<OnlyBicycleDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Bicycle bicycle)
        {
            var bikePresentInCart = _onlyBicycleDbContext.ShoppingCartItems.Any(c => 
                c.ShoppingCartId == ShoppingCartId && 
                c.Bicycle.BicycleId == bicycle.BicycleId
            );

            if (bikePresentInCart) return;

            var cartItem = new ShoppingCartItem()
            {
                BicycleId = bicycle.BicycleId,
                ShoppingCartId = ShoppingCartId,
            };

            _onlyBicycleDbContext.ShoppingCartItems.Add(cartItem);
            _onlyBicycleDbContext.SaveChanges();
        }

        public int RemoveFromCart(Bicycle bicycle)
        {
            var shoppingCartItem =
                    _onlyBicycleDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Bicycle.BicycleId == bicycle.BicycleId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                _onlyBicycleDbContext.ShoppingCartItems.Remove(shoppingCartItem);
            }

            _onlyBicycleDbContext.SaveChanges();
            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??= _onlyBicycleDbContext.ShoppingCartItems
                .Where(c => c.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Bicycle).ThenInclude(b => b.Category)
                .Include(s => s.Bicycle).ThenInclude(b => b.GenderCategory)
                .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _onlyBicycleDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _onlyBicycleDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _onlyBicycleDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _onlyBicycleDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Bicycle.RentCost).Sum(); // TODO : Rent cost * hours 
            return total;
        }
    }
}
