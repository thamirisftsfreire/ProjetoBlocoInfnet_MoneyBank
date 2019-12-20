using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Specifications
{
    public class PINMustBeFiveCharacters
    {
        public bool IsSatisfiedBy(int pin)
        {
            return pin.ToString().Length == 5;
        }
    }
}
