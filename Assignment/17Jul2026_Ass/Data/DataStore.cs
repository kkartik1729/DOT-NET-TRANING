using ShopEaseConsoleApp.Models;

namespace ShopEaseConsoleApp.Data
{
    /// <summary>
    /// Simple in-memory "database" shared by all services (singleton-style static store).
    /// </summary>
    public static class DataStore
    {
        public const string AdminUsername = "admin";
        public const string AdminPassword = "admin123";

        public static List<Customer> Customers { get; } = new();
        public static List<Category> Categories { get; } = new();
        public static List<Product> Products { get; } = new();
        public static List<Order> Orders { get; } = new();

        private static int _customerIdSeq = 1;
        private static int _categoryIdSeq = 1;
        private static int _productIdSeq = 1000;
        private static int _orderIdSeq = 5000;

        public static int NextCustomerId() => _customerIdSeq++;
        public static int NextCategoryId() => _categoryIdSeq++;
        public static int NextProductId() => ++_productIdSeq;
        public static int NextOrderId() => ++_orderIdSeq;

        // Session state
        public static Customer? LoggedInCustomer { get; set; }
        public static bool IsAdminLoggedIn { get; set; }

        static DataStore()
        {
            SeedCategories();
            SeedProducts();
        }

        private static void SeedCategories()
        {
            string[] defaults = { "Electronics", "Books", "Fashion", "Sports", "Furniture", "Groceries" };
            foreach (var name in defaults)
            {
                Categories.Add(new Category { Id = NextCategoryId(), Name = name });
            }
        }

        private static void SeedProducts()
        {
            Products.Add(new Product
            {
                Id = 1001,
                Name = "Laptop",
                Category = "Electronics",
                Description = "Dell Inspiron",
                Price = 65000,
                Quantity = 20,
                Brand = "Dell",
                Discount = 10,
                Rating = 4.6
            });
            _productIdSeq = 1001;
        }
    }
}
