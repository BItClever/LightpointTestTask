using AutoMapper;
using LightpointTestTask.BLL.Entities;
using LightpointTestTask.BLL.Infrastructure;
using LightpointTestTask.DAL;
using LightpointTestTask.DAL.Entities;
using LightpointTestTask.DAL.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace LightpointTestTask.BLL.Services
{
    public class ShopsService : IShopsService
    {
        private IUnitOfWork Database { get; }

        public ShopsService()
        {
            Database = new UnitOfWork();
        }

        public IEnumerable<ShopEntity> GetShops(IMapper mapper)
        {
            var result = new List<ShopEntity>();
            foreach (var item in Database.Shops.ReadAll())
            {
                result.Add(mapper.Map<ShopEntity>(item));
            }
            return result;
        }

        public ShopEntity GetShop(int id, IMapper mapper)
        {
            return mapper.Map<ShopEntity>(Database.Shops.Read(id));
        }

        public IEnumerable<ProductEntity> GetProducts(IMapper mapper)
        {
            var result = new List<ProductEntity>();
            foreach (var item in Database.Products.ReadAll())
            {
                result.Add(mapper.Map<ProductEntity>(item));
            }
            return result;
        }

        public IEnumerable<ProductEntity> GetProducts(int shopId, IMapper mapper)
        {
            var result = new List<ProductEntity>();
            foreach (var item in Database.Products.ReadAll().Where(x => x.ShopId == shopId))
            {
                result.Add(mapper.Map<ProductEntity>(item));
            }
            return result;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void AddProduct(ProductEntity product, IMapper mapper)
        {
            Database.Products.Create(mapper.Map<Product>(product));
            Database.Save();
        }

        public void RemoveProduct(int productId)
        {
            Database.Products.Delete(productId);
            Database.Save();
        }

        public void UpdateProduct(ProductEntity product)
        {
            var toUpdate = Database.Products.Read(product.ProductId);

            if (product != null)
            {
                toUpdate.Name = product.Name;
                toUpdate.Description = product.Description;
            }
            Database.Products.Update(toUpdate);
            Database.Save();
        }
    }
}
