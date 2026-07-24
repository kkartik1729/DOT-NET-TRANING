namespace ShopEaseConsoleApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; } = string.Empty;
        public decimal Discount { get; set; }   // percentage, e.g. 10 = 10%
        public double Rating { get; set; }

        public decimal DiscountedPrice => Math.Round(Price - (Price * Discount / 100), 2);

        public override string ToString()
        {
            return $"[{Id}] {Name,-15} | {Category,-10} | Brand: {Brand,-10} | " +
                   $"Price: {Price,8:C} | Disc: {Discount,4}% | Final: {DiscountedPrice,8:C} | " +
                   $"Qty: {Quantity,4} | Rating: {Rating}/5";
        }
    }
}
