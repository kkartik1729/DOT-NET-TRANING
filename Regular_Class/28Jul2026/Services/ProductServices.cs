using _28Jul2026.Models;

namespace _28Jul2026.Services
{
    public class ProductServices : IProduct
    {
        // In-memory sample data. Static so it persists across requests
        // within the same running instance of the app.
        private static readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop",   Category = "Electronics", Price = 78000, Quantity = 15 },
            new Product { Id = 2, Name = "Mouse",    Category = "Electronics", Price = 900,   Quantity = 100 },
            new Product { Id = 3, Name = "Keyboard", Category = "Electronics", Price = 1500,  Quantity = 60 },
            new Product { Id = 4, Name = "Monitor",  Category = "Electronics", Price = 12000, Quantity = 25 }
        };

        private static int _nextId = 5;

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product? GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public Product Add(Product product)
        {
            product.Id = _nextId++;
            _products.Add(product);
            return product;
        }

        public bool Update(int id, Product product)
        {
            var existing = _products.FirstOrDefault(p => p.Id == id);
            if (existing == null) return false;

            existing.Name = product.Name;
            existing.Category = product.Category;
            existing.Price = product.Price;
            existing.Quantity = product.Quantity;
            return true;
        }

        public bool Delete(int id)
        {
            var existing = _products.FirstOrDefault(p => p.Id == id);
            if (existing == null) return false;

            _products.Remove(existing);
            return true;
        }
    }
}
