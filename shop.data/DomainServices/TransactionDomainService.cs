using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop.domain;

namespace shop.data.DomainServices
{
    public class TransactionDomainService(ShopContext _dbContext) : DomainServiceBase<Transaction>(_dbContext), ITransactionDomainService
    {
        public async Task<IEnumerable<Transaction>> GetAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Transaction> InsertAsync(Transaction transaction)
        {
            DbSet.Add(transaction);
            await Db.SaveChangesAsync();
            return transaction;
        }

        public async Task<int> UpdateAsync(Transaction transaction)
        {
            DbSet.Update(transaction);
            return await Db.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var transaction = await DbSet.FindAsync(id);
            if (transaction != null) DbSet.Remove(transaction); //<--- shouldn't we use ExecuteDeleteAsync?
            return await Db.SaveChangesAsync();
        }
    }

    public interface ITransactionDomainService
    {
        Task<IEnumerable<Transaction>> GetAsync();
        Task<Transaction> InsertAsync(Transaction transaction);
        Task<int> UpdateAsync(Transaction transaction);
        Task<int> DeleteAsync(Guid id);
    }
}
