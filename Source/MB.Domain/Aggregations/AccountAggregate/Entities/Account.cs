using System;

namespace MB.Domain.Aggregations.AccountAggregate.Entities
{
    public class Account : EntityBase<Guid>
    {
        public int PIN { get; set; }
        public Decimal AvailableBalance { get; set; }
        public Decimal TotalBalance { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}
