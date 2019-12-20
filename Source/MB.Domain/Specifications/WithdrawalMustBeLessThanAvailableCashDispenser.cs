using MB.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Specifications
{
    public class WithdrawalMustBeLessThanAvailableCashDispenser
    {
        public bool IsSatisfiedBy(Amount withdrawalAmount, Amount _cashDispenser)
        {
            return withdrawalAmount.Value <= _cashDispenser.Value;
        }
    }
}
