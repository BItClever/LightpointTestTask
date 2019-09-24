namespace LightpointTestTask.WEB.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ShopId { get; set; }
        public ShopModel Shop { get; set; }
    }
}
