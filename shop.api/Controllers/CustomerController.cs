using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shop.api.Dto;
using shop.data;
using shop.domain;

namespace shop.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ShopContext _context;

        public CustomerController(ShopContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            return Ok(await _context.Customers.Select(c => new CustomerDto(c)).ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(Guid id, CustomerDto customerDto)
        {
            return Ok(await _context.Customers.Where(c => c.CustomerId == id).ExecuteUpdateAsync(setters =>
                    setters.SetProperty(customer => customer.FirstName, customerDto.FirstName)
                    .SetProperty(customer => customer.LastName, customerDto.LastName)
                    .SetProperty(customer => customer.Age, customerDto.Age)
                    .SetProperty(customer => customer.BankDetails, customerDto.BankDetails)));
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> PostCustomer(CustomerDto customerDto)
        {
            Customer customer = customerDto.ToDomain();
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok(customer.CustomerId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            return Ok(await _context.Customers.Where(c => c.CustomerId == id).ExecuteDeleteAsync());
        }

    }

}