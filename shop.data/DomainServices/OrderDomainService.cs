using Microsoft.EntityFrameworkCore;
using shop.domain;

namespace shop.data.DomainServices
{
    public class OrderDomainService(ShopContext _dbContext) : DomainServiceBase<Order>(_dbContext), IOrderDomainService
    {

        public async Task<IEnumerable<Order>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetAsyncWithRelatedData()
        {
            return (await DbSet.Include(o => o.ProductsInOrder).ToListAsync());
        }

        /*
        public Order ClearRelatedDataCircularReferencing(Order o)
        {
            o.ProductInOrders.ForEach(p => {
                p.Transactions.Clear();
                p.Suppliers.ForEach(pS => pS.Products.Clear());
            });
            return o;
        }
        */

        public async Task<Order> InsertAsync(Order order)
        {
            DbSet.Add(order);
            await Db.SaveChangesAsync();
            return order;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var order = await DbSet.FindAsync(id);
            if (order != null) DbSet.Remove(order); //<--- shouldn't we use ExecuteDeleteAsync?
            return await Db.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(Order order)
        {
            DbSet.Update(order);
            return await Db.SaveChangesAsync();
        }

        public async Task<int> AddProductLinkAsync(Guid orderId, Guid linkedProductId, int amount)
        {
            await Db.ProductOrderJoinTable.AddAsync(new ProductInOrder() { OrderId = orderId, ProductId = linkedProductId, Quantity = amount });
            return await Db.SaveChangesAsync();
        }

        public async Task<int> RemoveProductLinkAsync(Guid orderId, Guid linkedProductId)
        {
            return await Db.ProductOrderJoinTable.Where(pO => pO.OrderId == orderId && pO.ProductId == linkedProductId).ExecuteDeleteAsync();
        }
    }

    public interface IOrderDomainService
    {
        Task<IEnumerable<Order>> GetAsync();
        Task<IEnumerable<Order>> GetAsyncWithRelatedData();
        Task<Order> InsertAsync(Order order);
        Task<int> DeleteAsync(Guid id);
        Task<int> UpdateAsync(Order order);
        Task<int> AddProductLinkAsync(Guid orderId, Guid linkedProductId, int amount);
        Task<int> RemoveProductLinkAsync(Guid orderId, Guid linkedProductId);
    }
}
