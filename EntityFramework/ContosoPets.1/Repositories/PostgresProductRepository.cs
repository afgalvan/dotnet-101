using System.Collections.Generic;
using System.Linq;
using ContosoPets._1.Data;
using ContosoPets._1.Models;

namespace ContosoPets._1.Repositories
{
    public class PostgresProductRepository : IProductRepository
    {
        private readonly ContosoPetsContext _context;

        public PostgresProductRepository(ContosoPetsContext context)
        {
            context.Database.EnsureCreated();
            _context = context;
        }

        public void Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product FindById(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Remove(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
