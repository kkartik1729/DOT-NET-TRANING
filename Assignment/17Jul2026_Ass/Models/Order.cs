namespace ShopEaseConsoleApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string ShippingAddress { get; set; } = string.Empty;
        public List<OrderItem> Items { get; set; } = new();

        public decimal SubTotal { get; set; }
        public decimal CouponDiscount { get; set; }
        public decimal Gst { get; set; }
        public decimal GrandTotal { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Placed;

        public override string ToString()
        {
            return $"Order #{Id} | {OrderDate:dd-MMM-yyyy HH:mm} | Items: {Items.Count} | " +
                   $"Grand Total: {GrandTotal:C} | Payment: {PaymentMethod} ({PaymentStatus}) | Status: {Status}";
        }
    }
}
