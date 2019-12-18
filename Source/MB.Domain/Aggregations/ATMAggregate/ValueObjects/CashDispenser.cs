using MB.Domain.Aggregations.ATMAggregate.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Aggregations.ATMAggregate.ValueObjects
{
    public class CashDispenser
    {
        private static Decimal INITIAL_COUNT = 500;
        public Decimal BillCount { get; set; }

        public CashDispenser()
        {
            BillCount = INITIAL_COUNT;
        }

        public Boolean DispenseCash(decimal amount) { return true; }

        public bool IsSufficientCashAvailable(decimal amount)
        {
            return new WithdrawalMustBeLessThanAvailableCashDispenser().IsSufficientCashAvailable(amount);
        }

    }
}
