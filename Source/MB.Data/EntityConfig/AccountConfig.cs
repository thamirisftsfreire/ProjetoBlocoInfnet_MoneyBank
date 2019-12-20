using MB.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MB.Domain.ValueObjects;

namespace MB.Data.EntityConfig
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Client)
                .WithOne(x => x.Account)
                .HasForeignKey<Client>(x => x.Id);

            builder
                .HasBaseType<Account>()
                .Property(transaction => transaction.TotalAmount)
                .HasConversion(
                    amount => amount.ToString(),
                    amount => Amount.Parse(amount))
                .HasColumnName("Amount");

        }
    }
}
