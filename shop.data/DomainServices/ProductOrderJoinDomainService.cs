using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop.domain;

namespace shop.data.DomainServices
{
    public class ProductOrderJoinDomainService(ShopContext _dbContext) : DomainServiceBase<ProductOrder>(_dbContext), IProductOrderJoinDomainService
    {
        public async Task<int> GetAmountForProductInOrder(Guid orderId, Guid productId)
        {
            return (await DbSet.Where(pO => pO.ProductId == productId && pO.OrderId == orderId).FirstOrDefaultAsync()).Amount;
        }
    }

    public interface IProductOrderJoinDomainService
    {
        Task<int> GetAmountForProductInOrder(Guid orderId, Guid productId);
    }
}
