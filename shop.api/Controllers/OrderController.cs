using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.api.Dto;
using shop.api.Mappers;
using shop.data.DomainServices;

namespace shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderDomainService orderService) : ControllerBase
    {

        [HttpGet("{customerId}")]
        public async Task<ActionResult<OrderDto>> GetOrdersOfCustomer(Guid customerId)
        {
            var ordersOfCustomer = await orderService.GetOrdersOfCustomerAsync(customerId);
            return Ok(ordersOfCustomer.Select(OrderMapper.ToDto));
        }

    }
}
