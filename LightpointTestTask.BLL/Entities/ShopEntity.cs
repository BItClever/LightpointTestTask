using System.Collections.Generic;

namespace LightpointTestTask.BLL.Entities
{
    public class ShopEntity
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string WorkingHours { get; set; }
        public IList<ProductEntity> Products { get; set; }
    }
}
