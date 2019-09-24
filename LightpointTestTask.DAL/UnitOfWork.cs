using LightpointTestTask.DAL.Entities;
using LightpointTestTask.DAL.Infrastructure;
using LightpointTestTask.DAL.Repositories;

namespace LightpointTestTask.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShopsContext DataBase { get; }
        private ProductRepository productRepository;
        private ShopRepository shopRepository;

        public UnitOfWork()
        {
            DataBase = new ShopsContext();
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(DataBase);
                return productRepository;
            }
        }

        public IRepository<Shop> Shops
        {
            get
            {
                if (shopRepository == null)
                    shopRepository = new ShopRepository(DataBase);
                return shopRepository;
            }
        }
        public void Dispose()
        {
            DataBase.Dispose();
        }

        public void Save()
        {
            DataBase.SaveChanges();
        }
    }
}
