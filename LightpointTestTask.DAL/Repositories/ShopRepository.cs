using LightpointTestTask.DAL.Entities;
using LightpointTestTask.DAL.Infrastructure;
using System;
using System.Collections.Generic;

namespace LightpointTestTask.DAL.Repositories
{
    public class ShopRepository : IRepository<Shop>
    {
        private readonly ShopsContext _database;

        public ShopRepository(ShopsContext context)
        {
            _database = context;
        }
        public void Create(Shop item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Shop Read(int id)
        {
            return _database.Shops.Find(id);
        }

        public IEnumerable<Shop> ReadAll()
        {
            return _database.Shops;
        }

        public void Update(Shop item)
        {
            throw new NotImplementedException();
        }
    }
}
