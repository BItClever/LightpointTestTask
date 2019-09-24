namespace LightpointTestTask.BLL.Entities
{
    public class ProductEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ShopId { get; set; }
        public ShopEntity Shop { get; set; }
    }
}
