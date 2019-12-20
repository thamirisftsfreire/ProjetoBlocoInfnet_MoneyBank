using MB.Domain.Entities;
using MB.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        Amount GetAvailableBalance(int accountId);
        Amount GetTotalBalance(int accountId);
        void Credit(int accountId, Decimal ValorCredito);
        void Debit(int accountId, Decimal ValorDebito);
        int GetAccountNumber(int accountId);
        Boolean ValidatePIN(Account account);
    }
}
