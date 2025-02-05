using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop.domain;

namespace shop.data.DomainServices
{
    public class CartDomainService(ShopContext _dbContext) : DomainServiceBase<Cart>(_dbContext), ICartDomainService
    {

        public async Task<bool> AddCartProductToCartAsync(Guid CartId, Guid ProductId, int Quantity)
        {
            var cart = await DbSet.Include(c => c.CartProducts).FirstOrDefaultAsync(c => c.CartId == CartId);

            if (cart == null) return false;

            CartProduct? cartProductOfProductId = cart.CartProducts.FindAll(cP => cP.ProductId == ProductId).FirstOrDefault();
            if (cartProductOfProductId != null)
            {
                cartProductOfProductId.Quantity += Quantity;
                DbSet.Update(cart);
            }
            else
            {
                CartProduct newCartProduct = new CartProduct { CartId = CartId, ProductId = ProductId, Quantity = Quantity };
                Db.CartProducts.Add(newCartProduct);
            }
            if (await Db.SaveChangesAsync() == 0) return false;
            return true;
        }

    }

    public interface ICartDomainService
    {
        Task<bool> AddCartProductToCartAsync(Guid CartId, Guid ProductId, int Quantity);

    }
}
