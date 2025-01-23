namespace shop.domain
{
    public class ProductOrderJ
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Amount { get; set; }
    }
}
