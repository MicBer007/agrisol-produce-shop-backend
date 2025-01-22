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

        public async Task<IEnumerable<Product>> GetAsyncWithRelatedData()
        {
            return (await DbSet.Include(p => p.Suppliers).Include(p => p.Orders).ToListAsync()).Select(RemoveCircularReferencesFromRelatedData);
        }

        public Product RemoveCircularReferencesFromRelatedData(Product p)
        {
            p.Suppliers.ForEach(pS => pS.Products.Clear());
            p.Orders.ForEach(o => o.Products.Clear());
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

        public async Task<int> AddOrderLinkAsync(Guid productId, Guid linkedOrderId, int amount)
        {
            await Db.ProductOrderJoinTable.AddAsync(new ProductOrder() { ProductId = productId, OrderId = linkedOrderId, Amount = amount});
            return await Db.SaveChangesAsync();
        }

        public async Task<int> RemoveOrderLinkAsync(Guid productId, Guid linkedOrderId)
        {
            return await Db.ProductOrderJoinTable.Where(pO => pO.ProductId == productId && pO.OrderId == linkedOrderId).ExecuteDeleteAsync();
        }
    }

    public interface IProductDomainService
    {
        Task<IEnumerable<Product>> GetAsync();
        Task<IEnumerable<Product>> GetAsyncWithRelatedData();
        Task<Product> InsertAsync(Product product);
        Task<int> UpdateAsync(Product product);
        Task<int> DeleteAsync(Guid id);
        Task<int> AddProductSupplierLinkAsync(Guid productId, Guid linkedProductSupplierId);
        Task<int> RemoveProductSupplierLinkAsync(Guid productId, Guid linkedProductSupplierId);
        Task<int> AddOrderLinkAsync(Guid productId, Guid linkedOrderId, int amount);
        Task<int> RemoveOrderLinkAsync(Guid productId, Guid linkedOrderId);
    }

}
