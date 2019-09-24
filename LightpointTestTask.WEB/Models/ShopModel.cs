using System.Collections.Generic;

namespace LightpointTestTask.WEB.Models
{
    public class ShopModel
    {
        public int ShopId { get; private set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string WorkingHours { get; set; }
        public IList<ProductModel> Products { get; set; }
    }
}
