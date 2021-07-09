using System.Collections.Generic;
using ContosoPets._1.Models;

namespace ContosoPets._1.Repositories
{
    public interface IProductRepository
    {
        void Save(Product product);
        Product FindById(int id);
        IEnumerable<Product> GetAll();
        void Remove(Product product);
        void Update(Product product);
    }
}
