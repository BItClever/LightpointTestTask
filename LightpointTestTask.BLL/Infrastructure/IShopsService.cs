using AutoMapper;
using LightpointTestTask.BLL.Entities;
using System;
using System.Collections.Generic;

namespace LightpointTestTask.BLL.Infrastructure
{
    public interface IShopsService : IDisposable
    {
        IEnumerable<ShopEntity> GetShops(IMapper mapper);
        IEnumerable<ProductEntity> GetProducts(int shopId, IMapper mapper);
        IEnumerable<ProductEntity> GetProducts(IMapper mapper);
        ShopEntity GetShop(int id, IMapper mapper);

        void AddProduct(ProductEntity product, IMapper mapper);
        void RemoveProduct(int productId);
        void UpdateProduct(ProductEntity product);
    }
}
