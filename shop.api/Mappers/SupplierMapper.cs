using shop.api.Dto;
using shop.domain;

namespace shop.api.Mappers
{
    public class SupplierMapper
    {

        public static SupplierDto ToDto(Supplier Supplier)
        {
            SupplierDto dto = new()
            {
                SupplierId = Supplier.SupplierId,
                SupplierName = Supplier.SupplierName,
                ProductSupplierJoins = Supplier.ProductSupplierJoins.Select(pS => ProductSupplierJoinMapper.ToDtoFromType(pS, Supplier.GetType())).ToList()
            };
            return dto;
        }

        public static SupplierDto ToDtoFromType(Supplier Supplier, Type objectType)
        {
            SupplierDto dto = new()
            {
                SupplierId = Supplier.SupplierId,
                SupplierName = Supplier.SupplierName
            };
            if (objectType != typeof(ProductSupplierJoin)) dto.ProductSupplierJoins = Supplier.ProductSupplierJoins.Select(pS => ProductSupplierJoinMapper.ToDtoFromType(pS, typeof(Supplier))).ToList();
            return dto;
        }

        public static Supplier ToDomain(SupplierDto Supplier)
        {
            List<ProductSupplierJoin> productSupplierJoin = Supplier.ProductSupplierJoins.Select(ProductSupplierJoinMapper.ToDomain).ToList();
            Guid SupplierId = Supplier.SupplierId == null ? Guid.NewGuid() : (Guid)Supplier.SupplierId;
            Supplier model = new()
            {
                SupplierId = SupplierId,
                SupplierName = Supplier.SupplierName,
                ProductSupplierJoins = productSupplierJoin
            };
            return model;
        }

    }
}
