using Microsoft.EntityFrameworkCore;
using shop.data;
using shop.data.DomainServices;

namespace shop.api
{
    public class ServicesModule : IModule
    {
        public void Configure(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var _dbContext = serviceScope.ServiceProvider.GetRequiredService<ShopContext>();
            _dbContext.Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductDomainService, ProductDomainService>();
            services.AddScoped<ICustomerDomainService, CustomerDomainService>();
            services.AddScoped<ITransactionDomainService, TransactionDomainService>();
        }
    }

    public interface IModule
    {
        void ConfigureServices(IServiceCollection services);
        void Configure(IApplicationBuilder app);
    }
}
