using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop.domain;

namespace shop.data.DomainServices
{
    public class CustomerDomainService(ShopContext _dbContext) : DomainServiceBase<Customer>(_dbContext), ICustomerDomainService
    {
        public async Task<IEnumerable<Customer>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Customer> InsertAsync(Customer customer)
        {
            DbSet.Add(customer);
            await Db.SaveChangesAsync();
            return customer;
        }

        public async Task<int> UpdateAsync(Customer customer)
        {
            DbSet.Update(customer);
            return await Db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var customer = await DbSet.FindAsync(id);
            if (customer != null) DbSet.Remove(customer); //<--- shouldn't we use ExecuteDeleteAsync?
            return await Db.SaveChangesAsync();
        }
    }

    public interface ICustomerDomainService
    {
        Task<IEnumerable<Customer>> GetAsync();
        Task<Customer> InsertAsync(Customer customer);
        Task<int> UpdateAsync(Customer customer);
        Task<int> DeleteAsync(Guid id);
    }

}
