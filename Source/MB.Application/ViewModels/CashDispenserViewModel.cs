using MB.Domain.Aggregations.ATMAggregate.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Application.ViewModels
{
    public class CashDispenserViewModel
    {
        private static Decimal INITIAL_COUNT = 500;
        public Decimal BillCount { get; set; }

        public CashDispenserViewModel()
        {
            BillCount = INITIAL_COUNT;
        }

        public Boolean DispenseCash(decimal amount) 
        {
            if (!IsSufficientCashAvailable(amount))
                return false;

            BillCount = BillCount - amount;
            return true;
        }

        public bool IsSufficientCashAvailable(decimal amount)
        {
            return new WithdrawalMustBeLessThanAvailableCashDispenser().IsSatisfiedBy(amount, BillCount);
        }

    }
}
