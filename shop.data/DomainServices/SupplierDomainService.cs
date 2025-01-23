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
    public class SupplierDomainService(ShopContext _dbContext): DomainServiceBase<Supplier>(_dbContext), IProductSupplierDomainService
    {

        public async Task<IEnumerable<Supplier>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<Supplier>> GetAsyncWithRelatedData()
        {
            return (await DbSet.Include(pS => pS.Products).ThenInclude(p => p.Orders).ToListAsync()).Select(RemoveCircularReferencesFromRelatedData);
        }

        private Supplier RemoveCircularReferencesFromRelatedData(Supplier supplier)
        {
            supplier.Products.ForEach(p =>
            {
                p.Suppliers.Clear();
                p.Orders.ForEach(o => o.Products.Clear());
            });
            return supplier;
        }

        public async Task<Supplier> InsertAsync(Supplier productSupplier)
        {
            DbSet.Add(productSupplier);
            await Db.SaveChangesAsync();
            return productSupplier;
        }

        public async Task<int> UpdateAsync(Supplier productSupplier)
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
            await Db.ProductSupplierJoins.AddAsync(new ProductSupplierJ() { ProductId = linkedProductId, SupplierId = productSupplierId });
            return await Db.SaveChangesAsync();
        }

        public async Task<int> RemoveProductLinkAsync(Guid productSupplierId, Guid linkedProductId)
        {
            return await Db.ProductSupplierJoins.Where(pPS => pPS.SupplierId == productSupplierId && pPS.ProductId == linkedProductId).ExecuteDeleteAsync();
        }

        public async Task<DateTime> GetMomentCreated(Guid productSupplierId, Guid linkedProductId)
        {
            return (await Db.ProductSupplierJoins.Where(pPS => pPS.ProductId == linkedProductId && pPS.SupplierId == productSupplierId).FirstOrDefaultAsync()).MomentCreated;
        }

    }

    public interface IProductSupplierDomainService
    {
        Task<IEnumerable<Supplier>> GetAsync();
        Task<IEnumerable<Supplier>> GetAsyncWithRelatedData();
        Task<Supplier> InsertAsync(Supplier productSupplier);
        Task<int> UpdateAsync(Supplier productSupplier);
        Task<int> DeleteAsync(Guid id);
        Task<int> AddProductLinkAsync(Guid productSupplierId, Guid linkedProductId);
        Task<int> RemoveProductLinkAsync(Guid productSupplierId, Guid linkedProductId);
        Task<DateTime> GetMomentCreated(Guid productSupplierId, Guid linkedProductId);
    }

}
