using LightpointTestTask.DAL.Entities;
using LightpointTestTask.DAL.Infrastructure;
using System.Collections.Generic;

namespace LightpointTestTask.DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ShopsContext _database;

        public ProductRepository(ShopsContext context)
        {
            _database = context;
        }
        public void Create(Product item)
        {
            _database.Products.Add(item);
        }

        public void Delete(int id)
        {
            var product = _database.Products.Find(id);
            if (product != null)
                _database.Products.Remove(product);
        }

        public Product Read(int id)
        {
            return _database.Products.Find(id);
        }

        public IEnumerable<Product> ReadAll()
        {
            return _database.Products;
        }

        public void Update(Product item)
        {
            _database.Products.Update(item);
        }
    }
}
