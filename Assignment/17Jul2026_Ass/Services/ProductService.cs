using ShopEaseConsoleApp.Data;
using ShopEaseConsoleApp.Models;

namespace ShopEaseConsoleApp.Services
{
    public class ProductService
    {
        public List<Product> GetAll() => DataStore.Products;

        public Product Add(string name, string category, string description, decimal price,
                            int quantity, string brand, decimal discount, double rating)
        {
            var product = new Product
            {
                Id = DataStore.NextProductId(),
                Name = name,
                Category = category,
                Description = description,
                Price = price,
                Quantity = quantity,
                Brand = brand,
                Discount = discount,
                Rating = rating
            };
            DataStore.Products.Add(product);
            return product;
        }

        public Product? GetById(int id) => DataStore.Products.FirstOrDefault(p => p.Id == id);

        public bool Update(int id, string name, string category, string description, decimal price,
                            int quantity, string brand, decimal discount, double rating)
        {
            var product = GetById(id);
            if (product == null) return false;

            product.Name = name;
            product.Category = category;
            product.Description = description;
            product.Price = price;
            product.Quantity = quantity;
            product.Brand = brand;
            product.Discount = discount;
            product.Rating = rating;
            return true;
        }

        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product == null) return false;
            DataStore.Products.Remove(product);
            return true;
        }

        public List<Product> Search(string keyword)
        {
            keyword = keyword.Trim().ToLower();
            return DataStore.Products.Where(p =>
                p.Name.ToLower().Contains(keyword) ||
                p.Category.ToLower().Contains(keyword) ||
                p.Brand.ToLower().Contains(keyword)).ToList();
        }

        public bool ReduceStock(int id, int quantity)
        {
            var product = GetById(id);
            if (product == null || product.Quantity < quantity) return false;
            product.Quantity -= quantity;
            return true;
        }
    }
}
