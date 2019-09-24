using AutoMapper;
using LightpointTestTask.BLL.Entities;
using LightpointTestTask.DAL.Entities;

namespace LightpointTestTask.BLL
{
    public class MappingProfileDALtoBLL : Profile
    {
        public MappingProfileDALtoBLL()
        {
            CreateMap<ProductEntity, Product>();
            CreateMap<Product, ProductEntity>();

            CreateMap<ShopEntity, Shop>();
            CreateMap<Shop, ShopEntity>();
        }
    }
}
