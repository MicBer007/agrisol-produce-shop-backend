using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using shop.api.Dto;
using shop.data.DomainServices;
using shop.domain;

namespace shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderDomainService orderService, IProductInOrderDomainService productOrderJoinService, IMapper mapper): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await orderService.GetAsync();
            return Ok(mapper.Map<IEnumerable<OrderDto>>(orders));
        }

        [HttpGet("WithRelated")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersWithRelatedData()
        {
            var orders = await orderService.GetAsyncWithRelatedData();
            var orderDtos = mapper.Map<IEnumerable<OrderDto>>(orders);
           /*
            foreach (OrderDto order in orderDtos)
            {
                foreach (ProductDto product in order.Products)
                {
                    order.Amounts.Add(await productOrderJoinService.GetAmountForProductInOrder((Guid) order.OrderId, (Guid) product.ProductId));
                }
            }
           */
            return Ok(orderDtos);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<OrderDto>> PostOrder(OrderDto orderDto)
        { /*
            if (orderDto.Products != null && orderDto.Products.Count > 0) throw new ArgumentException("No new products should be initialized when declaring an Order!");
            */
            var order = await orderService.InsertAsync(mapper.Map<Order>(orderDto));
            return Ok(mapper.Map<OrderDto>(order));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var rowsChanged = await orderService.DeleteAsync(id);

            if (rowsChanged == 0) return BadRequest("Entry not found");

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PutOrder([FromBody] OrderDto orderDto)
        {
            /*
            if (orderDto.Products != null && orderDto.Products.Count > 0) throw new ArgumentException("No new products should be initialized when updating an Order!");
            */
            var order = mapper.Map<Order>(orderDto);
            int rowsChanged = await orderService.UpdateAsync(order);

            if (rowsChanged == 0) return BadRequest("Database error");

            return NoContent();
        }

        [HttpPut("Linkproduct")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> CreateLinkToProduct(Guid orderId, Guid productId, int amount)
        {
            int rowsChanged = await orderService.AddProductLinkAsync(orderId, productId, amount);

            if (rowsChanged == 0) return BadRequest("Database error");

            return NoContent();
        }

        [HttpPut("UnlinkProduct")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> RemoveLinkToProduct(Guid orderId, Guid productId)
        {

            int rowsChanged = await orderService.RemoveProductLinkAsync(orderId, productId);

            if (rowsChanged == 0) return BadRequest("Database error");

            return NoContent();
        }

    }
}
