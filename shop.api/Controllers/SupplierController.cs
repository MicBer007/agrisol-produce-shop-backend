using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shop.api.Dto;
using shop.data.DomainServices;
using shop.domain;

namespace shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController(IProductSupplierDomainService productSupplierService, IMapper mapper): ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetSuppliers()
        {
            var suppliers = await productSupplierService.GetAsync();
            return Ok(mapper.Map<IEnumerable<SupplierDto>>(suppliers));
        }

        [HttpGet("WithRelated")]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetSuppliersWithProducts()
        {
            var suppliersWithProducts = await productSupplierService.GetAsyncWithRelatedData();
            return Ok(mapper.Map<IEnumerable<SupplierDto>>(suppliersWithProducts));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<Supplier>> PostSupplier(SupplierDto productSupplierDto)
        {
            if (productSupplierDto.Products != null && productSupplierDto.Products.Count > 0) throw new ArgumentException("No Products should be initialized in the declaration of a Product Supplier!");
            var supplier = await productSupplierService.InsertAsync(mapper.Map<Supplier>(productSupplierDto));
            return Ok(mapper.Map<SupplierDto>(supplier));
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
        public async Task<IActionResult> PutSupplier([FromBody] SupplierDto supplierDto)
        {
            if (supplierDto.Products != null && supplierDto.Products.Count > 0) throw new ArgumentException("No Products should be initialized when updating a Product Supplier!");
            var productSupplier = mapper.Map<Supplier>(supplierDto);
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
