using ShopEaseConsoleApp.Data;
using ShopEaseConsoleApp.Models;

namespace ShopEaseConsoleApp.Services
{
    public class CategoryService
    {
        public List<Category> GetAll() => DataStore.Categories;

        public Category Add(string name)
        {
            if (DataStore.Categories.Any(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("Category already exists.");

            var category = new Category { Id = DataStore.NextCategoryId(), Name = name };
            DataStore.Categories.Add(category);
            return category;
        }

        public bool Update(int id, string newName)
        {
            var category = DataStore.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return false;

            var oldName = category.Name;
            category.Name = newName;

            // Keep product category names in sync
            foreach (var p in DataStore.Products.Where(p => p.Category == oldName))
                p.Category = newName;

            return true;
        }

        public bool Delete(int id)
        {
            var category = DataStore.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return false;

            if (DataStore.Products.Any(p => p.Category == category.Name))
                throw new InvalidOperationException("Cannot delete: products exist in this category.");

            DataStore.Categories.Remove(category);
            return true;
        }
    }
}
