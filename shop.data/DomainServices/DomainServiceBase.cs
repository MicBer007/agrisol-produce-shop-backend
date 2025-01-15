using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace shop.data.DomainServices
{
    public class DomainServiceBase<TDomain>(ShopContext _dbContext) where TDomain: class
    {

        protected readonly ShopContext Db = _dbContext;
        protected readonly DbSet<TDomain> DbSet = _dbContext.Set<TDomain>();

    }
}
