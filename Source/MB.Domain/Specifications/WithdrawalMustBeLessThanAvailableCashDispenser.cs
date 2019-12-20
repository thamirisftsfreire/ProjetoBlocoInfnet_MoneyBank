using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Specifications
{
    public class WithdrawalMustBeLessThanAvailableCashDispenser
    {
        public bool IsSatisfiedBy(Decimal withdrawalAmount, Decimal _cashDispenser)
        {
            return withdrawalAmount <= _cashDispenser;
        }
    }
}
