using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using shop.api.Dto;
using shop.api.Mappers;
using shop.data.DomainServices;
using shop.domain;

namespace shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerDomainService customerService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customers = await customerService.GetCustomersAsync();
            return Ok(customers.Select(CustomerMapper.ToDto));
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerById(Guid customerId)
        {
            var customer = await customerService.GetCustomerByIdAsync(customerId);
            return Ok(CustomerMapper.ToDto(customer));
        }

        [HttpGet("Orders/{customerId}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerByIdWithOrders(Guid customerId)
        {
            var customerWithOrders = await customerService.GetCustomerByIdWithOrdersAsync(customerId);
            return Ok(CustomerMapper.ToDto(customerWithOrders));
        }

        [HttpGet("Cart/{customerId}")]
        public async Task<ActionResult<CustomerDto>> GetCustomerByIdWithCart(Guid customerId)
        {
            var customerWithOrders = await customerService.GetCustomerByIdWithCartAsync(customerId);
            return Ok(CustomerMapper.ToDto(customerWithOrders));
        }

    }

}