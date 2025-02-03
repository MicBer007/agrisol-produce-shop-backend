using shop.api.Dto;
using shop.domain;

namespace shop.api.Mappers
{
    public class ProductSupplierJoinMapper
    {
        public static ProductSupplierJoinDto ToDto(ProductSupplierJoin Join)
        {
            if (Join == null) return null;
            ProductSupplierJoinDto dto = new()
            {
                MomentCreated = Join.MomentCreated,
                Product = ProductMapper.ToDtoFromType(Join.Product, Join.GetType()),
                Supplier = SupplierMapper.ToDtoFromType(Join.Supplier, Join.GetType())
            };
            return dto;
        }

        public static ProductSupplierJoinDto ToDtoFromType(ProductSupplierJoin ProductSupplierJoin, Type objectType)
        {
            if (ProductSupplierJoin == null) return null;
            ProductSupplierJoinDto dto = new()
            {
                MomentCreated = ProductSupplierJoin.MomentCreated
            };
            if (objectType != typeof(Product)) dto.Product = ProductMapper.ToDtoFromType(ProductSupplierJoin.Product, typeof(ProductSupplierJoin));
            if (objectType != typeof(Supplier)) dto.Supplier = SupplierMapper.ToDtoFromType(ProductSupplierJoin.Supplier, typeof(ProductSupplierJoin));
            return dto;
        }

        public static ProductSupplierJoin ToDomain(ProductSupplierJoinDto dto)
        {
            if (dto == null) return null;
            Product product = ProductMapper.ToDomain(dto.Product);
            Supplier supplier = SupplierMapper.ToDomain(dto.Supplier);
            ProductSupplierJoin model = new()
            {
                Product = product,
                ProductId = product.ProductId,
                Supplier = supplier,
                SupplierId = supplier.SupplierId,
                MomentCreated = dto.MomentCreated
            };
            return model;
        }

    }
}
