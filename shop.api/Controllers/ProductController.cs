using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.api.Dto;
using shop.data;
using shop.domain;

namespace shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductController(ShopContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            return Ok(await _context.Products.Select(p => new ProductDto(p)).ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Guid id, ProductDto productDto)
        {
            return Ok(await _context.Products.Where(p => p.ProductId == id).ExecuteUpdateAsync(setters =>
                    setters.SetProperty(product => product.Name, productDto.Name)
                    .SetProperty(product => product.InStock, productDto.InStock)
                    .SetProperty(product => product.Price, productDto.Price)
                    .SetProperty(product => product.PictureName, productDto.PictureName)));
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDto productDto)
        {
            Product product = productDto.ToDomain();
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(product.ProductId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            return Ok(await _context.Products.Where(p => p.ProductId == id).ExecuteDeleteAsync());
        }

    }

}
