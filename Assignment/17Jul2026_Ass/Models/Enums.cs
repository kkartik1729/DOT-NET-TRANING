namespace ShopEaseConsoleApp.Models
{
    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        UPI,
        CashOnDelivery
    }

    public enum PaymentStatus
    {
        Success,
        Failed,
        Pending
    }

    public enum OrderStatus
    {
        Placed,
        Shipped,
        Delivered,
        Cancelled
    }
}
