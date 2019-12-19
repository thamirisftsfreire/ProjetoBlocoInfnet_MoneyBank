using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Aggregations.AccountAggregate.Specifications
{
    public class AccountMustBeFiveCharacters
    {
        public bool IsSatisfiedBy(int accountNumber)
        {
            return accountNumber.ToString().Length <= 5;
        }
    }
}
