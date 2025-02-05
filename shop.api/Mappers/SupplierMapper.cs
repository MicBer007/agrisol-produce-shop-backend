using shop.api.Dto;
using shop.domain;

namespace shop.api.Mappers
{
    public class SupplierMapper
    {

        public static SupplierDto ToDto(Supplier Supplier)
        {
            if (Supplier == null) return null;
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
            if (Supplier == null) return null;
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
            Guid SupplierId = Supplier.SupplierId == null ? Guid.NewGuid() : (Guid)Supplier.SupplierId;
            Supplier model = new()
            {
                SupplierId = SupplierId,
                SupplierName = Supplier.SupplierName,
                ProductSupplierJoins = []
            };
            return model;
        }

    }
}
