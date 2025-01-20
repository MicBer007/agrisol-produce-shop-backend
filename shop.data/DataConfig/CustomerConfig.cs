using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using shop.domain;

namespace shop.data.DataConfig
{
    public class CustomerConfig: IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> cBuilder)
        {
            Customer[] Customers = {
                new Customer {CustomerId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D"), FirstName = "Harald", LastName = "Berndt", Age = 54, BankDetails = "Capitec:5492875"},
                new Customer {CustomerId = new Guid("95CDCF59-5D79-4FED-B5E5-771F9E7A2F30"), FirstName = "Mauro", LastName = "Lavista", Age = 32, BankDetails = "Absa:475693"}
            };
            cBuilder.Property(c => c.CustomerId).ValueGeneratedOnAdd();
            cBuilder.HasData(Customers);
            cBuilder.ToTable("customer");
        }
    }
}
