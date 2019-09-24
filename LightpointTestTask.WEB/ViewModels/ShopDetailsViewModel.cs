using LightpointTestTask.WEB.Models;
using System.Collections.Generic;

namespace LightpointTestTask.WEB.ViewModels
{
    public class ShopDetailsViewModel
    {
        public ShopModel Shop { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }
    }
}
