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

        public async Task<IEnumerable<Product>> GetAsyncWithSuppliers()
        {
            return (await DbSet.Include(p => p.Suppliers).ToListAsync()).Select(p => ClearProductSupplierProductsList(p));
        }

        public Product ClearProductSupplierProductsList(Product p)
        {
            p.Suppliers.ForEach(pS => pS.Products.Clear());
            return p;
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

        public async Task<int> AddProductSupplierLinkAsync(Guid productId, Guid linkedProductSupplierId)
        {
            await Db.ProductProductSuppliersJoinTable.AddAsync(new ProductProductSupplier() { ProductId = productId, ProductSupplierId = linkedProductSupplierId });
            return await Db.SaveChangesAsync();
        }

        public async Task<int> RemoveProductSupplierLinkAsync(Guid productId, Guid linkedProductSupplierId)
        {
            return await Db.ProductProductSuppliersJoinTable.Where(pPS => pPS.ProductSupplierId == linkedProductSupplierId && pPS.ProductId == productId).ExecuteDeleteAsync();
        }
    }

    public interface IProductDomainService
    {
        Task<IEnumerable<Product>> GetAsync();
        Task<IEnumerable<Product>> GetAsyncWithSuppliers();
        Task<Product> InsertAsync(Product product);
        Task<int> UpdateAsync(Product product);
        Task<int> DeleteAsync(Guid id);
        Task<int> AddProductSupplierLinkAsync(Guid productId, Guid linkedProductSupplierId);
        Task<int> RemoveProductSupplierLinkAsync(Guid productId, Guid linkedProductSupplierId);
    }

}
