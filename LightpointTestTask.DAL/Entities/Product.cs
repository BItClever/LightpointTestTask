namespace LightpointTestTask.DAL.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Shop Shop { get; set; }
        public int ShopId { get; set; }
    }
}
