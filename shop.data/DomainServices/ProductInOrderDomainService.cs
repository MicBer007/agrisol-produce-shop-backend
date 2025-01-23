using Microsoft.EntityFrameworkCore;
using shop.domain;

namespace shop.data.DomainServices
{
    public class ProductInOrderDomainService(ShopContext _dbContext) : DomainServiceBase<ProductInOrder>(_dbContext), IProductInOrderDomainService
    {
        public async Task<int> GetAmountForProductInOrder(Guid orderId, Guid productId)
        {
            return (await DbSet.Where(pO => pO.ProductId == productId && pO.OrderId == orderId).FirstOrDefaultAsync()).Quantity;
        }

        public async Task<IEnumerable<ProductInOrder>> GetByCustomerId(Guid customerId)
        {
            return await DbSet
                .Where(pO => pO.Order.CustomerId == customerId)
                .Include(po => po.Order)          
                .Include(po => po.Product)
                .ToListAsync();
        }   
    }

    public interface IProductInOrderDomainService
    {
        Task<int> GetAmountForProductInOrder(Guid orderId, Guid productId);
        Task<IEnumerable<ProductInOrder>> GetByCustomerId(Guid customerId);
    }
}
