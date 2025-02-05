using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop.domain;

namespace shop.data.DomainServices
{
    public class OrderDomainService(ShopContext _dbContext) : DomainServiceBase<Order>(_dbContext), IOrderDomainService
    {
        public async Task<IEnumerable<Order>> GetOrdersOfCustomerAsync(Guid CustomerId)
        {
            return await DbSet.Include(o => o.OrderProducts).ThenInclude(oP => oP.Product).Where(o => o.CustomerId == CustomerId).ToListAsync();
        }
    }

    public interface IOrderDomainService
    {
        Task<IEnumerable<Order>> GetOrdersOfCustomerAsync(Guid CustomerId);
    }

}
