using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop.domain;

namespace shop.data.DomainServices
{
    public class ProductProductSupplierJoinDomainService(ShopContext _dbContext) : DomainServiceBase<ProductProductSupplier>(_dbContext), IProductProductSupplierJoinDomainService
    {
        public async Task<DateTime> GetMomentJoinCreated(Guid productId, Guid productSupplierId)
        {
            return (await DbSet.Where(pPS => pPS.ProductId == productId && pPS.ProductSupplierId == productSupplierId).FirstOrDefaultAsync()).MomentCreated;
        }
    }

    public interface IProductProductSupplierJoinDomainService
    {
        Task<DateTime> GetMomentJoinCreated(Guid productId, Guid productSupplierId);
    }

}
