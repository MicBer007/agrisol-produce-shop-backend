using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.api.Dto;
using shop.data.DomainServices;
using shop.domain;

namespace shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSupplierController(IProductSupplierDomainService productSupplierService, IMapper mapper): ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSupplierDto>>> GetSuppliers()
        {
            var suppliers = await productSupplierService.GetAsync();
            return Ok(mapper.Map<IEnumerable<ProductSupplierDto>>(suppliers));
        }

        [HttpGet("Products")]
        public async Task<ActionResult<IEnumerable<ProductSupplierDto>>> GetSuppliersWithProducts()
        {
            var suppliersWithProducts = await productSupplierService.GetAsyncWithProducts();
            return Ok(mapper.Map<IEnumerable<ProductSupplierDto>>(suppliersWithProducts));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<ProductSupplier>> PostSupplier(ProductSupplierDto productSupplierDto)
        {
            if (productSupplierDto.Products != null && productSupplierDto.Products.Count > 0) throw new ArgumentException("No Products should be initialized in the declaration of a Product Supplier!");
            var supplier = await productSupplierService.InsertAsync(mapper.Map<ProductSupplier>(productSupplierDto));
            return Ok(mapper.Map<ProductSupplierDto>(supplier));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteSupplier(Guid id)
        {
            var rowsChanged = await productSupplierService.DeleteAsync(id);

            if (rowsChanged == 0) return BadRequest("Entry not found");

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PutSupplier([FromBody] ProductSupplierDto supplierDto)
        {
            if (supplierDto.Products != null && supplierDto.Products.Count > 0) throw new ArgumentException("No Products should be initialized when updating a Product Supplier!");
            var productSupplier = mapper.Map<ProductSupplier>(supplierDto);
            int rowsChanged = await productSupplierService.UpdateAsync(productSupplier);

            if (rowsChanged == 0) return BadRequest("Database error");

            return NoContent();
        }

        [HttpPut("LinkProduct")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> CreateLinkToProduct(Guid supplierId, Guid productId)
        {
            int rowsChanged = await productSupplierService.AddProductLinkAsync(supplierId, productId);

            if (rowsChanged == 0) return BadRequest("Database error");

            return NoContent();
        }

        [HttpPut("UnlinkProduct")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> RemoveLinkToProduct(Guid supplierId, Guid productId)
        {

            int rowsChanged = await productSupplierService.RemoveProductLinkAsync(supplierId, productId);

            if (rowsChanged == 0) return BadRequest("Database error");

            return NoContent();
        }
    }
}
