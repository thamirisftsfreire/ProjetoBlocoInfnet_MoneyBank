using MB.Domain.Aggregations.AccountAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Aggregations.AccountAggregate.Interfaces.Services
{
    public interface IAccountService
    {
        Decimal GetAvailableBalance(int accountId);
        Decimal GetTotalBalance(int accountId);
        void Credit(int accountId, Decimal ValorCredito);
        void Debit(int accountId, Decimal ValorDebito);
        int GetAccountNumber(int accountId);
        Boolean ValidatePIN(Account account);
    }
}
