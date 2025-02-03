using Microsoft.EntityFrameworkCore;
using shop.domain;

namespace shop.data.DomainServices
{
    public class ProductDomainService(ShopContext _dbContext) : DomainServiceBase<Product>(_dbContext), IProductDomainService
    {

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid ProductId)
        {
            return await DbSet.FindAsync(ProductId);
        }

        public async Task<Product> GetProductByIdWithSuppliersAsync(Guid ProductId)
        {
            return await DbSet.Include(c => c.ProductSupplierJoins).ThenInclude(pS => pS.Supplier).FirstOrDefaultAsync(p => p.ProductId == ProductId);
        }
    }

    public interface IProductDomainService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(Guid ProductId);
        Task<Product> GetProductByIdWithSuppliersAsync(Guid ProductId);
    }

}
