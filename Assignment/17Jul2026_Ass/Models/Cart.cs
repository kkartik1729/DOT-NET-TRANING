namespace ShopEaseConsoleApp.Models
{
    public class Cart
    {
        public int CustomerId { get; set; }
        public List<CartItem> Items { get; set; } = new();
        public string? CouponCode { get; set; }
        public decimal CouponDiscountPercent { get; set; } = 0;

        public decimal SubTotal => Items.Sum(i => i.LineTotal);
        public decimal CouponDiscountAmount => Math.Round(SubTotal * CouponDiscountPercent / 100, 2);
        public decimal GstAmount => Math.Round((SubTotal - CouponDiscountAmount) * 0.18m, 2);
        public decimal GrandTotal => SubTotal - CouponDiscountAmount + GstAmount;

        public bool IsEmpty => Items.Count == 0;
    }
}
