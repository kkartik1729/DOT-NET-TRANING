using _28Jul2026.Models;

namespace _28Jul2026.Services
{
    public interface IProduct
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        Product Add(Product product);
        bool Update(int id, Product product);
        bool Delete(int id);
    }
}
