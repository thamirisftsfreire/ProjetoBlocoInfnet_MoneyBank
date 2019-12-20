using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Interfaces.Services
{
    public interface ITransactionService
    {
        void Execute(int accountNumber);
        void Execute(int accountNumber, Decimal amount);
    }
}
