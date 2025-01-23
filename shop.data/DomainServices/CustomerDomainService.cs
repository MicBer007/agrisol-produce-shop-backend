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

        public async Task<Customer> GetCustomerByIdAsync(Guid customerId)
        {
            return await DbSet.FindAsync(customerId);
        }

        public async Task<Customer> GetCustomerByIdWithOrdersAsync(Guid CustomerId)
        {
            return await DbSet.Include(c => c.Orders).ThenInclude(o => o.OrderProducts).ThenInclude(oP => oP.Product).Include(oP => oP.Orders).FirstOrDefaultAsync(c => c.CustomerId == CustomerId);
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            if (customer.Orders != null || customer.Orders.Count > 0) throw new ArgumentException("Orders should be empty when adding a new customer!");
            DbSet.Add(customer);
            await Db.SaveChangesAsync();
            return customer;
        }

        public async Task<int> DeleteCustomerAsync(Guid customerId)
        {
            var customer = await DbSet.FindAsync(customerId);
            if (customer != null) DbSet.Remove(customer);
            return await Db.SaveChangesAsync();
        }

        public async Task<int> UpdateCustomerAsync(Customer customer)
        {
            DbSet.Update(customer);
            return await Db.SaveChangesAsync();
        }
    }

    public interface ICustomerDomainService
    {
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(Guid CustomerId);
        Task<Customer> GetCustomerByIdWithOrdersAsync(Guid CustomerId);
        Task<Customer> AddCustomerAsync(Customer customer);
        Task<int> DeleteCustomerAsync(Guid CustomerId);
        Task<int> UpdateCustomerAsync(Customer customer);
    }

}
