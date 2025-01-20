using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop.domain;

//Convention for M-M relationships:
//delete (PARAMS: the entity's ID)
//update (PARAMS: the new entity, but with the same ID)
//create (PARAMS: the entity to be created) [RETURNS: the new entity / the new entity ID]
//basic get [RETURNS: the base Entity]
//get with dependant entity IDs [RETURNS: the Entity with the IDs of the dependant Entities]
//add link (PARAMS: the dependant's ID) //update call?
//remove link (PARAMS: the dependant's ID) //update call?

//Convention for 1-M relationships as principal:
//delete (PARAMS: the entity's ID) {deletes the dependants as well}
//update (PARAMS: the new entity, but with the same ID)
//create (PARAMS: the entity to be created) [RETURNS: the new entity / the new entity ID]
//basic get [RETURNS: the base Entity]
//get with dependant entity IDs [RETURNS: the Entity with the IDs of the dependants]
//add dependant (PARAMS: the dependant)
//remove dependant (PARAMS: the dependant's ID)

//Convention for 1-M relationships as dependant:
//delete (PARAMS: the entity's ID) {deletes the link to the principal}
//update (PARAMS: the new entity, but with the same ID)
//create (PARAMS: the entity to be created) [RETURNS: the new entity / the new entity ID]
//get [RETURNS: the base Entity with it's principal's ID]

namespace shop.data.DomainServices
{
    public class ProductSupplierDomainService(ShopContext _dbContext): DomainServiceBase<ProductSupplier>(_dbContext), IProductSupplierDomainService
    {

        public async Task<IEnumerable<ProductSupplier>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<ProductSupplier>> GetAsyncWithProducts()
        {
            return (await DbSet.Include(pS => pS.Products).ToListAsync()).Select(pS => ClearSupplierProductSuppliersList(pS));
        }

        public ProductSupplier ClearSupplierProductSuppliersList(ProductSupplier pS)
        {
            pS.Products.ForEach(p => p.Suppliers.Clear());
            return pS;
        }

        public async Task<ProductSupplier> InsertAsync(ProductSupplier productSupplier)
        {
            DbSet.Add(productSupplier);
            await Db.SaveChangesAsync();
            return productSupplier;
        }

        public async Task<int> UpdateAsync(ProductSupplier productSupplier)
        {
            DbSet.Update(productSupplier);
            return await Db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var supplier = await DbSet.FindAsync(id);
            if (supplier != null) DbSet.Remove(supplier); //<--- shouldn't we use ExecuteDeleteAsync?
            return await Db.SaveChangesAsync();
        }

        public async Task<int> AddProductLinkAsync(Guid productSupplierId, Guid linkedProductId)
        {
            await Db.ProductProductSuppliersJoinTable.AddAsync(new ProductProductSupplier() { ProductId = linkedProductId, ProductSupplierId = productSupplierId });
            return await Db.SaveChangesAsync();
        }

        public async Task<int> RemoveProductLinkAsync(Guid productSupplierId, Guid linkedProductId)
        {
            return await Db.ProductProductSuppliersJoinTable.Where(pPS => pPS.ProductSupplierId == productSupplierId && pPS.ProductId == linkedProductId).ExecuteDeleteAsync();
        }

    }

    public interface IProductSupplierDomainService
    {
        Task<IEnumerable<ProductSupplier>> GetAsync();
        Task<IEnumerable<ProductSupplier>> GetAsyncWithProducts();
        Task<ProductSupplier> InsertAsync(ProductSupplier productSupplier);
        Task<int> UpdateAsync(ProductSupplier productSupplier);
        Task<int> DeleteAsync(Guid id);
        Task<int> AddProductLinkAsync(Guid productSupplierId, Guid linkedProductId);
        Task<int> RemoveProductLinkAsync(Guid productSupplierId, Guid linkedProductId);
    }

}
