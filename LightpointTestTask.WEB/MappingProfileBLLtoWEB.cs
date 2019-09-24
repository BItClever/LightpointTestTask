using AutoMapper;
using LightpointTestTask.BLL.Entities;
using LightpointTestTask.WEB.Models;

namespace LightpointTestTask.WEB
{
    public class MappingProfileBLLtoWEB : Profile
    {
        public MappingProfileBLLtoWEB()
        {
            CreateMap<ProductEntity, ProductModel>();
            CreateMap<ProductModel, ProductEntity>();

            CreateMap<ShopEntity, ShopModel>();
            CreateMap<ShopModel, ShopEntity>();

            
        }
    }
}
