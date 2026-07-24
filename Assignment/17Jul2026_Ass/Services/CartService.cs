using ShopEaseConsoleApp.Models;

namespace ShopEaseConsoleApp.Services
{
    public class CartService
    {
        // key = customerId
        private readonly Dictionary<int, Cart> _carts = new();

        private static readonly Dictionary<string, decimal> CouponCodes = new()
        {
            { "SAVE10", 10m },
            { "WELCOME50", 5m },
            { "FESTIVE20", 20m }
        };

        public Cart GetCart(int customerId)
        {
            if (!_carts.TryGetValue(customerId, out var cart))
            {
                cart = new Cart { CustomerId = customerId };
                _carts[customerId] = cart;
            }
            return cart;
        }

        public void AddToCart(int customerId, Product product, int quantity)
        {
            var cart = GetCart(customerId);
            var existing = cart.Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existing != null)
                existing.Quantity += quantity;
            else
                cart.Items.Add(new CartItem { Product = product, Quantity = quantity });
        }

        public bool RemoveItem(int customerId, int productId)
        {
            var cart = GetCart(customerId);
            var item = cart.Items.FirstOrDefault(i => i.Product.Id == productId);
            if (item == null) return false;
            cart.Items.Remove(item);
            return true;
        }

        public bool UpdateQuantity(int customerId, int productId, int newQuantity)
        {
            var cart = GetCart(customerId);
            var item = cart.Items.FirstOrDefault(i => i.Product.Id == productId);
            if (item == null) return false;

            if (newQuantity <= 0)
                cart.Items.Remove(item);
            else
                item.Quantity = newQuantity;
            return true;
        }

        public void ClearCart(int customerId)
        {
            var cart = GetCart(customerId);
            cart.Items.Clear();
            cart.CouponCode = null;
            cart.CouponDiscountPercent = 0;
        }

        public bool ApplyCoupon(int customerId, string code)
        {
            var cart = GetCart(customerId);
            if (!CouponCodes.TryGetValue(code.ToUpper(), out var percent))
                return false;

            cart.CouponCode = code.ToUpper();
            cart.CouponDiscountPercent = percent;
            return true;
        }
    }
}
