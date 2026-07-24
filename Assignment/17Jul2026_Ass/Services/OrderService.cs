using ShopEaseConsoleApp.Data;
using ShopEaseConsoleApp.Models;

namespace ShopEaseConsoleApp.Services
{
    public class OrderService
    {
        private readonly ProductService _productService;

        public OrderService(ProductService productService)
        {
            _productService = productService;
        }

        public Order PlaceOrder(Customer customer, Cart cart, string shippingAddress,
                                 PaymentMethod method, PaymentStatus paymentStatus)
        {
            if (cart.IsEmpty)
                throw new InvalidOperationException("Cart is empty.");

            var order = new Order
            {
                Id = DataStore.NextOrderId(),
                CustomerId = customer.Id,
                CustomerName = customer.Name,
                ShippingAddress = shippingAddress,
                PaymentMethod = method,
                PaymentStatus = paymentStatus,
                SubTotal = cart.SubTotal,
                CouponDiscount = cart.CouponDiscountAmount,
                Gst = cart.GstAmount,
                GrandTotal = cart.GrandTotal
            };

            foreach (var item in cart.Items)
            {
                order.Items.Add(new OrderItem
                {
                    ProductId = item.Product.Id,
                    ProductName = item.Product.Name,
                    UnitPrice = item.Product.DiscountedPrice,
                    Quantity = item.Quantity
                });

                _productService.ReduceStock(item.Product.Id, item.Quantity);
            }

            DataStore.Orders.Add(order);
            return order;
        }

        public List<Order> GetOrderHistory(int customerId) =>
            DataStore.Orders.Where(o => o.CustomerId == customerId)
                             .OrderByDescending(o => o.OrderDate)
                             .ToList();

        public Order? SearchOrder(int customerId, int orderId) =>
            DataStore.Orders.FirstOrDefault(o => o.CustomerId == customerId && o.Id == orderId);

        public bool CancelOrder(int customerId, int orderId)
        {
            var order = SearchOrder(customerId, orderId);
            if (order == null) return false;
            if (order.Status is OrderStatus.Delivered or OrderStatus.Cancelled) return false;

            order.Status = OrderStatus.Cancelled;
            return true;
        }

        public List<Order> GetAllOrders() =>
            DataStore.Orders.OrderByDescending(o => o.OrderDate).ToList();
    }
}
