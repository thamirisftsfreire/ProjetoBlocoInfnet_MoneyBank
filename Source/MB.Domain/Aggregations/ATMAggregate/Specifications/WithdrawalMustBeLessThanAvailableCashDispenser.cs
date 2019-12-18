using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Aggregations.ATMAggregate.Specifications
{
    public class WithdrawalMustBeLessThanAvailableCashDispenser
    {
        public Boolean IsSufficientCashAvailable(decimal amount) { return true; }
    }
}
