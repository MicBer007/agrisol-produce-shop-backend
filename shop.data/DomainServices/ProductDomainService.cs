using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using shop.domain;

namespace shop.data.DomainServices
{
    public class ProductDomainService(ShopContext _dbContext): DomainServiceBase<Product>(_dbContext), IProductDomainService
    {
        public async Task<IEnumerable<Product>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Product> InsertAsync(Product product)
        {
            DbSet.Add(product);
            await Db.SaveChangesAsync();
            return product;
        }

        public async Task<int> UpdateAsync(Product product)
        {
            DbSet.Update(product);
            return await Db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var product = await DbSet.FindAsync(id);
            if (product != null) DbSet.Remove(product); //<--- shouldn't we use ExecuteDeleteAsync?
            return await Db.SaveChangesAsync();
        }
    }

    public interface IProductDomainService
    {
        Task<IEnumerable<Product>> GetAsync();
        Task<Product> InsertAsync(Product product);
        Task<int> UpdateAsync(Product product);
        Task<int> DeleteAsync(Guid id);
    }

}
