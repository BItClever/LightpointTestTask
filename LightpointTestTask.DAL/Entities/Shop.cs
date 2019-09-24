using System.Collections.Generic;

namespace LightpointTestTask.DAL.Entities
{
    public class Shop
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string WorkingHours { get; set; }
        public List<Product> Products { get; set; }
    }
}
