using MB.Domain.Entities;
using MB.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Specifications
{
    public class DepositMustBeGreaterThanZero
    {
        public bool IsSatisfiedBy(Decimal depositAmount)
        {
            return depositAmount > 0;
        }
    }
}
