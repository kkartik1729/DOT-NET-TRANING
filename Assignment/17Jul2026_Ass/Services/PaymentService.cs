using ShopEaseConsoleApp.Models;

namespace ShopEaseConsoleApp.Services
{
    public class PaymentService
    {
        private readonly Random _random = new();
        public PaymentStatus ProcessPayment(PaymentMethod method, decimal amount)
        {
            if (method == PaymentMethod.CashOnDelivery)
                return PaymentStatus.Pending;

            int roll = _random.Next(1, 101); // 1-100
            return roll <= 85 ? PaymentStatus.Success : PaymentStatus.Failed;
        }
    }
}
