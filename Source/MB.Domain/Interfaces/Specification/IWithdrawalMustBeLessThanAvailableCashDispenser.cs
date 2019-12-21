using MB.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Interfaces.Specification
{
    public interface IWithdrawalMustBeLessThanAvailableCashDispenser
    {
        bool IsSatisfiedBy(Amount withdrawalAmount, Amount _cashDispenser);
    }
}
