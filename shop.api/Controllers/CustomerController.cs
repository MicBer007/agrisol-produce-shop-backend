using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shop.api.Dto;
using shop.data.DomainServices;
using shop.domain;

namespace shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerDomainService customerService, IMapper mapper) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customers = await customerService.GetCustomersAsync();
            return Ok(mapper.Map<IEnumerable<CustomerDto>>(customers));
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(Guid customerId)
        {
            var customer = await customerService.GetCustomerByIdAsync(customerId);
            return Ok(mapper.Map<CustomerDto>(customer));
        }

        [HttpGet("Orders/{customerId}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerByIdWithOrders(Guid customerId)
        {
            var customerWithOrders = await customerService.GetCustomerByIdWithOrdersAsync(customerId);
            return Ok(mapper.Map<CustomerDto>(customerWithOrders));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDto>> AddNewCustomer(CustomerDto customer)
        {
            var addedCustomer = await customerService.AddCustomerAsync(mapper.Map<Customer>(customer));
            return Ok(mapper.Map<CustomerDto>(addedCustomer));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var rowsChanged = await customerService.DeleteCustomerAsync(id);
            if (rowsChanged == 0) return BadRequest("Entry not found");
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(204)]
        public async Task<IActionResult> PutCustomer([FromBody] CustomerDto customerDto)
        {
            int rowsChanged = await customerService.UpdateCustomerAsync(mapper.Map<Customer>(customerDto));
            if (rowsChanged == 0) return BadRequest("Database error");
            return NoContent();
        }

    }

}