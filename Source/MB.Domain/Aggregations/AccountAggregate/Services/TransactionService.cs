using MB.Domain.Aggregations.AccountAggregate.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Aggregations.AccountAggregate.Services
{
    public abstract class TransactionService : ITransactionService
    {
        public int AccountNumber { get; set; }
        public Decimal Amount { get; set; }

        public abstract void Execute();
    }
}
