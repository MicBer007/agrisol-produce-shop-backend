using Microsoft.EntityFrameworkCore;
using shop.domain;

namespace shop.data.DomainServices
{
    public class ProductProductSupplierJoinDomainService(ShopContext _dbContext) : DomainServiceBase<ProductSupplierJ>(_dbContext), IProductProductSupplierJoinDomainService
    {
        public async Task<DateTime> GetMomentJoinCreated(Guid productId, Guid productSupplierId)
        {
            return (await DbSet.Where(pPS => pPS.ProductId == productId && pPS.SupplierId == productSupplierId).FirstOrDefaultAsync()).MomentCreated;
        }
    }

    public interface IProductProductSupplierJoinDomainService
    {
        Task<DateTime> GetMomentJoinCreated(Guid productId, Guid productSupplierId);
    }

}
