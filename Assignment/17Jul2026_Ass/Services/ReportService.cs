using ShopEaseConsoleApp.Data;
using ShopEaseConsoleApp.Models;

namespace ShopEaseConsoleApp.Services
{
    public class ReportService
    {
        public int TotalCustomers() => DataStore.Customers.Count;

        public int TotalProducts() => DataStore.Products.Count;

        public int TotalOrders() => DataStore.Orders.Count;

        public decimal TotalRevenue() =>
            DataStore.Orders.Where(o => o.Status != OrderStatus.Cancelled)
                             .Sum(o => o.GrandTotal);

        public List<(Product Product, int UnitsSold)> TopSellingProducts(int topN = 5)
        {
            var sales = new Dictionary<int, int>();
            foreach (var order in DataStore.Orders.Where(o => o.Status != OrderStatus.Cancelled))
            {
                foreach (var item in order.Items)
                {
                    sales.TryGetValue(item.ProductId, out int current);
                    sales[item.ProductId] = current + item.Quantity;
                }
            }

            return sales
                .OrderByDescending(kv => kv.Value)
                .Take(topN)
                .Select(kv => (DataStore.Products.FirstOrDefault(p => p.Id == kv.Key), kv.Value))
                .Where(x => x.Item1 != null)
                .Select(x => (x.Item1!, x.Item2))
                .ToList();
        }

        public List<Product> LowStockProducts(int threshold = 5) =>
            DataStore.Products.Where(p => p.Quantity <= threshold).ToList();

        public List<Order> OrdersByStatus(OrderStatus status) =>
            DataStore.Orders.Where(o => o.Status == status).ToList();
    }
}
