namespace ShopEaseConsoleApp.Models
{
    public class CartItem
    {
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }

        public decimal LineTotal => Product.DiscountedPrice * Quantity;

        public override string ToString()
        {
            return $"{Product.Name,-15} x{Quantity,-3} @ {Product.DiscountedPrice:C} = {LineTotal:C}";
        }
    }
}
