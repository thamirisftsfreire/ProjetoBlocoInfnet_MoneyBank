using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Application.Interfaces
{
    public interface ITransactionAppService
    {
        void Execute(int accountNumber);
        void Execute(int accountNumber, decimal amount);
    }
}
