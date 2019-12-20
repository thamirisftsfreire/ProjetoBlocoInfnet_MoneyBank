using MB.Domain.ValueObjects;
using System;

namespace MB.Domain.Entities
{
    public class Account : BaseEntity<int>
    {
        public byte[] PIN { get; set; }
        public Amount TotalAmount { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}
