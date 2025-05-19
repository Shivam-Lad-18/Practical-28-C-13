using DotNet9_Project.Models;
using System.Xml.Linq;

namespace DotNet9_Project.Services
{
    public class ProductService : IProductService
    {
        // Collection expression [..] to initialize list
        private static readonly List<Product> _products = [
            new() { Id = 1, Name = "Laptop", Price = 1200, Category = "Electronics" },
            new() { Id = 2, Name = "Smartphone", Price = 800, Category = "Electronics" },
            new() { Id = 3, Name = "Table", Price = 150, Category = "Furniture" },
            new() { Id = 4, Name = "Chair", Price = 75, Category = "Furniture" }
        ];

        public IEnumerable<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product)
        {
            product.Id = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existing = GetById(product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.Category = product.Category;
                existing.Discount = product.Discount;
            }
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
                _products.Remove(product);
        }

    }
}
