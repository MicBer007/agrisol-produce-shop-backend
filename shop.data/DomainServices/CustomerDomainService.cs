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
        public async Task<IEnumerable<Customer>> GetAsyncWithRelatedData()
        {
            return (await DbSet.Include(c => c.Orders).ThenInclude(o => o.Products).ThenInclude(p => p.Suppliers).ToListAsync()).Select(RemoveCircularReferencesFromRelatedData);
        }

        public Customer RemoveCircularReferencesFromRelatedData(Customer customer)
        {
            customer.Orders.ForEach(o => o.Products.ForEach(p =>
            {
                p.Orders.Clear();
                p.Suppliers.ForEach(pS => pS.Products.Clear());
            }));
            return customer;
        }

        public async Task<Customer> InsertAsync(Customer customer)
        {
            if (customer.Orders != null && customer.Orders.Count > 0) throw new ArgumentOutOfRangeException("You cannot initialize a new Order when creating a customer! Rather include the customerId on an http call to create the order.");
            DbSet.Add(customer);
            await Db.SaveChangesAsync();
            return customer;
        }

        public async Task<int> UpdateAsync(Customer customer)
        {
            if (customer.Orders != null && customer.Orders.Count > 0) throw new ArgumentOutOfRangeException("You cannot initialize a new Order when updating a customer! Rather include the customerId on an http call to create the order.");
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
        Task<IEnumerable<Customer>> GetAsyncWithRelatedData();
        Task<Customer> InsertAsync(Customer customer);
        Task<int> UpdateAsync(Customer customer);
        Task<int> DeleteAsync(Guid id);
    }

}
