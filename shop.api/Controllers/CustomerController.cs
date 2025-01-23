using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shop.api.Dto;
using shop.data.DomainServices;
using shop.domain;

namespace shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerDomainService customerService, IProductInOrderDomainService productOrderJoinService, IMapper mapper): ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customers = await customerService.GetAsync();
            return Ok(mapper.Map<IEnumerable<CustomerDto>>(customers));
        }

        [HttpGet("WithOrders/{id}")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomersRelatedData(Guid id)
        {
            var customer = await customerService.GetAsyncWithOrdersById(id);
            var customerDto = mapper.Map<CustomerDto>(customer);
            /*
            foreach (CustomerDto customer in customerDtos)
            {
                foreach (OrderDto order in customer.Orders)
                {
                    foreach (ProductDto product in order.Products)
                    {
                        order.Amounts.Add(await productOrderJoinService.GetAmountForProductInOrder((Guid)order.OrderId, (Guid)product.ProductId));
                    }
                }
            }
            */
            return Ok(customerDto);
        }

        [HttpPut]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PutCustomer([FromBody] CustomerDto customerDto)
        {
            var customer = mapper.Map<Customer>(customerDto);
            int rowsChanged = await customerService.UpdateAsync(customer);

            if (rowsChanged == 0) return BadRequest("Database error");

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<CustomerDto>> PostCustomer(CustomerDto customerDto)
        {
            var customer = await customerService.InsertAsync(mapper.Map<Customer>(customerDto));
            return Ok(mapper.Map<CustomerDto>(customer));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var rowsChanged = await customerService.DeleteAsync(id);

            if (rowsChanged == 0) return BadRequest("Entry not found");

            return NoContent();
        }

    }

}