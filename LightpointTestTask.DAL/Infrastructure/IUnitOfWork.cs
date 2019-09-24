using LightpointTestTask.DAL.Entities;
using System;

namespace LightpointTestTask.DAL.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }
        IRepository<Shop> Shops { get; }
        void Save();
    }
}
