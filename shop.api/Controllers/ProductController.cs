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

        [HttpGet("Suppliers")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsWithSuppliers()
        {
            var productsWithSuppliers = await productService.GetAsyncWithSuppliers();
            return Ok(mapper.Map<IEnumerable<ProductDto>>(productsWithSuppliers));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<ProductDto>> PostProduct(ProductDto productDto)
        {
            if (productDto.Suppliers != null && productDto.Suppliers.Count > 0) throw new ArgumentException("No Product suppliers should be initialized when declaring a new Product!");
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

        [HttpPut]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PutProduct([FromBody] ProductDto productDto)
        {
            if (productDto.Suppliers != null && productDto.Suppliers.Count > 0) throw new ArgumentException("No Product suppliers should be initialized when updating a Product!");
            var product = mapper.Map<Product>(productDto);
            int rowsChanged = await productService.UpdateAsync(product);

            if (rowsChanged == 0) return BadRequest("Database error");

            return NoContent();
        }

        [HttpPut("LinkSupplier")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> CreateLinkToProduct(Guid productId, Guid supplierId)
        {
            int rowsChanged = await productService.AddProductSupplierLinkAsync(productId, supplierId);

            if (rowsChanged == 0) return BadRequest("Database error");

            return NoContent();
        }

        [HttpPut("UnlinkSupplier")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> RemoveLinkToProduct(Guid productId, Guid supplierId)
        {

            int rowsChanged = await productService.RemoveProductSupplierLinkAsync(productId, supplierId);

            if (rowsChanged == 0) return BadRequest("Database error");

            return NoContent();
        }

    }

}
