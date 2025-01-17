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
    public class TransactionConfig: IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> tBuilder)
        {
            Transaction[] Transactions = {
                new Transaction{TransactionId = new Guid("10987938-D34C-4809-AB86-9BA1671AD36F"), TransactionName = "Tomatoes", TransactionValue = 140, CustomerId = new Guid("4C004C7A-AA08-4714-9F2A-153DCE79154D")}
            };
            tBuilder.Property(t => t.TransactionId).ValueGeneratedOnAdd();
            tBuilder.Property(t => t.TransactionValue).HasColumnType("decimal(18,2)");
            tBuilder.HasData(Transactions);
            tBuilder.ToTable("transaction");
        }
    }
}
