using shop.domain;

namespace shop.api.Dto
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public string PictureName { get; set; }

        public ProductDto()
        {

        }
        public ProductDto(Product product)
        {
            ProductId = product.ProductId;
            Name = product.Name;
            InStock = product.InStock;
            PictureName = product.PictureName;
            Price = product.Price;
        }
        public Product ToDomain()
        {
            return new Product
            {
                ProductId = ProductId,
                Name = Name,
                InStock = InStock,
                PictureName = PictureName,
                Price = Price
            };
        }

        public void FromDomain(Product product)
        {

            ProductId = product.ProductId;
            Name = product.Name;
            InStock = product.InStock;
            PictureName = product.PictureName;
            Price = product.Price;
        }

    }

}
