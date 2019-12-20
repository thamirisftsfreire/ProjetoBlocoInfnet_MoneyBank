using System;
using MB.Domain.Specifications;
using MB.Domain.ValueObjects;

namespace MB.Application.ViewModels
{
    public class CashDispenserViewModel
    {
        private static Amount INITIAL_COUNT = new Amount("USD", 500);
        public Amount BillCount { get; set; }

        public CashDispenserViewModel()
        {
            BillCount = INITIAL_COUNT;
        }

        public Boolean DispenseCash(Amount amount)
        {
            if (!IsSufficientCashAvailable(amount))
                return false;

            BillCount = BillCount - amount;
            return true;
        }

        public bool IsSufficientCashAvailable(Amount amount)
        {
            return new WithdrawalMustBeLessThanAvailableCashDispenser().IsSatisfiedBy(amount, BillCount);
        }

    }
}
