using Microsoft.EntityFrameworkCore;
using shop.domain;

namespace shop.data.DomainServices
{
    public class CustomerDomainService(ShopContext _dbContext) : DomainServiceBase<Customer>(_dbContext), ICustomerDomainService
    {

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid CustomerId)
        {
            return await DbSet.FindAsync(CustomerId);
        }

        public async Task<Customer> GetCustomerByIdWithOrdersAsync(Guid CustomerId)
        {
            return await DbSet.Include(c => c.Orders).ThenInclude(o => o.OrderProducts).ThenInclude(oP => oP.Product).Include(oP => oP.Orders).FirstOrDefaultAsync(c => c.CustomerId == CustomerId);
        }

        public async Task<Customer> GetCustomerByIdWithCartAsync(Guid CustomerId)
        {
            return await DbSet.Include(c => c.Cart).ThenInclude(c => c.CartProducts).ThenInclude(cP => cP.Product).FirstOrDefaultAsync(c => c.CustomerId == CustomerId);
        }

    }

    public interface ICustomerDomainService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(Guid CustomerId);
        Task<Customer> GetCustomerByIdWithOrdersAsync(Guid CustomerId);
        Task<Customer> GetCustomerByIdWithCartAsync(Guid CustomerId);
    }

}
