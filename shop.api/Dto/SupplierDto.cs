namespace shop.api.Dto
{
    public class SupplierDto
    {
        public Guid? SupplierId { get; set; }
        public string SupplierName { get; set; }
        public List<ProductSupplierJoinDto> ProductSupplierJoins { get; set; } = [];

    }
}
