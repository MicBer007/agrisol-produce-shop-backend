using shop.api.Dto;
using shop.domain;
using static NuGet.Packaging.PackagingConstants;

namespace shop.api.Mappers
{
    public class ProductMapper
    {

        public static ProductDto ToDto(Product Product)
        {
            ProductDto dto = new()
            {
                ProductId = Product.ProductId,
                Name = Product.Name,
                Price = Product.Price,
                InStock = Product.InStock,
                PictureName = Product.PictureName,
                ProductSupplierJoins = Product.ProductSupplierJoins.Select(pS => ProductSupplierJoinMapper.ToDtoFromType(pS, Product.GetType())).ToList(),
                OrderProducts = Product.OrderProducts.Select(oP => OrderProductMapper.ToDtoFromType(oP, Product.GetType())).ToList()
            };
            return dto;
        }

        public static ProductDto ToDtoFromType(Product Product, Type objectType)
        {
            ProductDto dto = new()
            {
                ProductId = Product.ProductId,
                Name = Product.Name,
                Price = Product.Price,
                InStock = Product.InStock,
                PictureName = Product.PictureName
            };
            if (objectType != typeof(OrderProduct)) dto.OrderProducts = Product.OrderProducts.Select(oP => OrderProductMapper.ToDtoFromType(oP, typeof(Product))).ToList();
            if (objectType != typeof(ProductSupplierJoin)) dto.ProductSupplierJoins = Product.ProductSupplierJoins.Select(pS => ProductSupplierJoinMapper.ToDtoFromType(pS, typeof(Product))).ToList();
            return dto;
        }

        public static Product ToDomain(ProductDto Product)
        {
            List<ProductSupplierJoin> joins = Product.ProductSupplierJoins.Select(s => ProductSupplierJoinMapper.ToDomain(s)).ToList();
            List<OrderProduct> orderProducts = Product.OrderProducts.Select(OrderProductMapper.ToDomain).ToList();
            Guid ProductId = Product.ProductId == null ? Guid.NewGuid() : (Guid)Product.ProductId;
            Product model = new()
            {
                ProductId = ProductId,
                Name = Product.Name,
                Price = Product.Price,
                InStock = Product.InStock,
                PictureName = Product.PictureName,
                ProductSupplierJoins = joins,
                OrderProducts = orderProducts
            };
            return model;
        }

    }
}
