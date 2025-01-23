namespace shop.api.Dto
{
    public class ProductWithoutOrderProductsDto
    {
        public Guid? ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public string PictureName { get; set; }
        public List<SupplierDto> Suppliers { get; set; } = [];
    }
}
