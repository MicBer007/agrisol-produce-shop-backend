using shop.api.Dto;
using shop.domain;
using static NuGet.Packaging.PackagingConstants;

namespace shop.api.Mappers
{
    public class ProductMapper
    {

        public static ProductDto ToDto(Product Product)
        {
            if (Product == null) return null;
            ProductDto dto = new()
            {
                ProductId = Product.ProductId,
                Name = Product.Name,
                Price = Product.Price,
                InStock = Product.InStock,
                PictureName = Product.PictureName,
                ProductSupplierJoins = Product.ProductSupplierJoins.Select(pS => ProductSupplierJoinMapper.ToDtoFromType(pS, Product.GetType())).ToList(),
                OrderProducts = Product.OrderProducts.Select(oP => OrderProductMapper.ToDtoFromType(oP, Product.GetType())).ToList(),
                CartProducts = Product.CartProducts.Select(cP => CartProductMapper.ToDtoFromType(cP, Product.GetType())).ToList()
            };
            return dto;
        }

        public static ProductDto ToDtoFromType(Product Product, Type objectType)
        {
            if (Product == null) return null;
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
            if (objectType != typeof(CartProduct)) dto.CartProducts = Product.CartProducts.Select(cP => CartProductMapper.ToDtoFromType(cP, typeof(Product))).ToList();
            return dto;
        }

        public static Product ToDomain(ProductDto Product)
        {
            if (Product == null) return null;
            List<ProductSupplierJoin> joins = Product.ProductSupplierJoins.Select(s => ProductSupplierJoinMapper.ToDomain(s)).ToList();
            List<OrderProduct> orderProducts = Product.OrderProducts.Select(OrderProductMapper.ToDomain).ToList();
            List<CartProduct> cartProducts = Product.CartProducts.Select(CartProductMapper.ToDomain).ToList();
            Guid ProductId = Product.ProductId == null ? Guid.NewGuid() : (Guid)Product.ProductId;
            Product model = new()
            {
                ProductId = ProductId,
                Name = Product.Name,
                Price = Product.Price,
                InStock = Product.InStock,
                PictureName = Product.PictureName,
                ProductSupplierJoins = joins,
                OrderProducts = orderProducts,
                CartProducts = cartProducts
            };
            return model;
        }

    }
}
