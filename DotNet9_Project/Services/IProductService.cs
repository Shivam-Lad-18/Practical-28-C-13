using DotNet9_Project.Models;

namespace DotNet9_Project.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();

        Product? GetById(int id);

        void Add(Product product);

        void Update(Product product);

        void Delete(int id);

    }
}
