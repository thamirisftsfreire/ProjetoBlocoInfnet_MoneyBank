using MB.Domain.ValueObjects;
using System;

namespace MB.Domain.Entities
{
    public class Account : BaseEntity<int>
    {
        public int PIN { get; set; }
        public Amount TotalAmount { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
