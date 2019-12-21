using MB.Domain.Interfaces.Specification;
using MB.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Application.AccountAppServices
{
    public class CashDispenserAppService
    {
        private readonly IWithdrawalMustBeLessThanAvailableCashDispenser
            _withdrawalMustBeLessThanAvailableCash;
        
        private static Amount INITIAL_COUNT = new Amount("USD", 500);
        public Amount BillCount { get; set; }

        public CashDispenserAppService(IWithdrawalMustBeLessThanAvailableCashDispenser
            withdrawalMustBeLessThanAvailableCash)
        {
            BillCount = INITIAL_COUNT;
            _withdrawalMustBeLessThanAvailableCash = withdrawalMustBeLessThanAvailableCash;
        }

        public Boolean DispenseCash(Amount amount)
        {
            if (!IsSufficientCashAvailable(amount))
                throw new Exception("Not enough money in the banknote dispenser.");

            BillCount = BillCount - amount;
            return true;
        }

        public bool IsSufficientCashAvailable(Amount amount)
        {
            return _withdrawalMustBeLessThanAvailableCash.IsSatisfiedBy(amount, BillCount);
        }
    }
}
