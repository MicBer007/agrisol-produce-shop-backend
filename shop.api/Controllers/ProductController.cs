using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.api.Dto;
using shop.api.Mappers;
using shop.data.DomainServices;

namespace shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductDomainService productService) : ControllerBase
    {


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var customers = await productService.GetProductsAsync();
            return Ok(customers.Select(ProductMapper.ToDto));
        }

        [HttpGet("Suppliers/{productId}")]
        public async Task<ActionResult<ProductDto>> GetProductByIdWithOrders(Guid productId)
        {
            var productWithOrders = await productService.GetProductByIdWithSuppliersAsync(productId);
            return Ok(ProductMapper.ToDto(productWithOrders));
        }
    }
}
