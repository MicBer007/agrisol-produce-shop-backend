using Microsoft.EntityFrameworkCore;

namespace shop.data.DomainServices
{
    public class DomainServiceBase<TDomain>(ShopContext _dbContext) where TDomain: class
    {

        protected readonly ShopContext Db = _dbContext;
        protected readonly DbSet<TDomain> DbSet = _dbContext.Set<TDomain>();

    }
}
