using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using shop.domain;

namespace shop.data.DomainServices
{
    public class CartCheckoutService(ShopContext _dbContext) : ICartCheckoutService
    {

        private readonly ShopContext Db = _dbContext;
        private readonly DbSet<Cart> CartDbSet = _dbContext.Carts;
        private readonly DbSet<Order> OrderDbSet = _dbContext.Orders;
        private readonly DbSet<CartProduct> CartProductsDbSet = _dbContext.CartProducts;
        private readonly DbSet<OrderProduct> OrderProductsDbSet = _dbContext.ProductOrderJoins;

        public async Task<Guid> CheckoutCartAsync(Guid cartId)
        {
            Cart Cart = await RetrieveCartWithCartProductsFromDatabase(cartId);

            if (Cart.CartProducts.Count == 0) throw new Exception("Cart could not be checked out, because it was already empty!");

            Order NewOrder = CreateNewOrderWithPayedStatus(Cart.CustomerId);
            AddOrderToDatabase(NewOrder);

            List<OrderProduct> OrderProducts = GetCartProductsAsOrderProductsWithOrderId(Cart.CartProducts, NewOrder.OrderId);
            AddOrderProductsToDatabase(OrderProducts);

            RemoveCartProductsFromDatabase(Cart.CartProducts);

            await SaveDatabaseChanges();

            return NewOrder.OrderId;
        }

        private async Task<Cart> RetrieveCartWithCartProductsFromDatabase(Guid cartId)
        {
            return await CartDbSet.Include(c => c.CartProducts).FirstAsync(c => c.CartId == cartId)
                ?? throw new Exception("The specified cart could not be found in the database!");
        }

        private Order CreateNewOrderWithPayedStatus(Guid customerId)
        {
            Guid orderId = Guid.NewGuid();

            Order Order = new Order() { OrderId = orderId, CustomerId = customerId };

            Order.OrderStatus = OrderStatus.Payed;
            Order.TimePayed = DateTime.Now;

            Order.TimeDelivered = null;
            Order.TimeCancelled = null;

            return Order;
        }

        private List<OrderProduct> GetCartProductsAsOrderProductsWithOrderId(List<CartProduct> CartProducts, Guid OrderId)
        {
            List<OrderProduct> OrderProducts = [];
            foreach (CartProduct cartProduct in CartProducts)
            {
                OrderProducts.Add(new OrderProduct() { OrderId = OrderId, ProductId = cartProduct.ProductId, Quantity = cartProduct.Quantity });
            }

            return OrderProducts;
        }

        private void AddOrderToDatabase(Order Order)
        {
            OrderDbSet.Add(Order);
        }

        private void AddOrderProductsToDatabase(List<OrderProduct> OrderProducts)
        {
            OrderProductsDbSet.AddRange(OrderProducts);
        }

        private void RemoveCartProductsFromDatabase(List<CartProduct> CartProducts)
        {
            CartProductsDbSet.RemoveRange(CartProducts);
        }

        private async Task SaveDatabaseChanges()
        {
            int dbRowsChanged = await Db.SaveChangesAsync();
            if (dbRowsChanged == 0) throw new Exception("Failed to add order to database!");
        }

    }

    public interface ICartCheckoutService
    {
        public Task<Guid> CheckoutCartAsync(Guid cartId);
    }
}
