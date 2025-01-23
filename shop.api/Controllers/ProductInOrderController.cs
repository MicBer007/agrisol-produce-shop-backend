using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shop.api.Dto;
using shop.data.DomainServices;

namespace shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInOrderController(IProductInOrderDomainService productOrderJoinDomainService, IMapper mapper) : ControllerBase
    {

        [HttpGet("ProductAmount")]
        public async Task<ActionResult<int>> GetAmountOfProduct(Guid productId, Guid orderId)
        {
            return Ok(await productOrderJoinDomainService.GetAmountForProductInOrder(productId, orderId));
        }

        [HttpGet("ByCustomer/{customerId}")]
        public async Task<ActionResult<IEnumerable<ProductInOrderDto>>> GetProductInOrdersByCustomer(Guid customerId)
        {
            var productInOrders = await productOrderJoinDomainService.GetByCustomerId(customerId);
            return Ok(mapper.Map<IEnumerable<ProductInOrderDto>>(productInOrders));
        }

    }
}
