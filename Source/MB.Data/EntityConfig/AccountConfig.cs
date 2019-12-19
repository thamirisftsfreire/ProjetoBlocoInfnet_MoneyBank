using MB.Domain.Aggregations.AccountAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

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

            builder.Ignore(x => x.AvailableBalance);
        }
    }
}
