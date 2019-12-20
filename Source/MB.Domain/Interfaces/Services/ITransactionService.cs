using MB.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Interfaces.Services
{
    public interface ITransactionService
    {
        Amount Execute(int accountNumber);
        void Execute(int accountNumber, Amount amount);
    }
}
