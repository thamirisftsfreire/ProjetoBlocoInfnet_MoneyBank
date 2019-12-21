﻿using MB.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Application.Interfaces
{
    public interface ICashDispenserAppService
    {
        Boolean DispenseCash(Amount amount);
        bool IsSufficientCashAvailable(Amount amount);
    }
}
