using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.api.Dto;
using shop.data;
using shop.data.DomainServices;
using shop.domain;

namespace shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductDomainService productService, IMapper mapper) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            var products = await productService.GetAsync();
            return Ok(mapper.Map<IEnumerable<ProductDto>>(products));
        }

        [HttpPut]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PutProduct([FromBody] ProductDto productDto)
        {

            var product = mapper.Map<Product>(productDto);
            int rowsChanged = await productService.UpdateAsync(product);

            if (rowsChanged == 0) return BadRequest("Database error");

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<ProductDto>> PostProduct(ProductDto productDto)
        {
            var product = await productService.InsertAsync(mapper.Map<Product>(productDto));
            return Ok(mapper.Map<ProductDto>(product));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var rowsChanged = await productService.DeleteAsync(id);

            if (rowsChanged == 0) return BadRequest("Entry not found");

            return NoContent();
        }

    }

}
