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

        public async Task<Order> GetOrderByIdAsync(Guid OrderId)
        {
            return await DbSet.Include(o => o.OrderProducts).ThenInclude(oP => oP.Product).FirstOrDefaultAsync(o => o.OrderId == OrderId);
        }

    }

    public interface IOrderDomainService
    {
        Task<IEnumerable<Order>> GetOrdersOfCustomerAsync(Guid CustomerId);
        Task<Order> GetOrderByIdAsync(Guid OrderId);
    }

}
