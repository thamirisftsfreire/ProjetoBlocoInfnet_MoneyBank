using MB.Domain.Aggregations.AccountAggregate.Entities;
using MB.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Aggregations.AccountAggregate.Specifications
{
    public class DepositMustBeGreaterThanZero
    {
        public bool IsSatisfiedBy(Decimal depositAmount)
        {
            return depositAmount > 0;
        }
    }
}
