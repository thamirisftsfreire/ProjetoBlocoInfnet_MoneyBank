using MB.Domain.Entities;
using MB.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Services
{
    public class WithdrawalService : IWithdrawalService
    {
        private readonly IBankDataBaseService _bankDatabaseService;
        WithdrawalService(IBankDataBaseService bankDatabaseService)
        {
            _bankDatabaseService = bankDatabaseService;
        }
        public void Execute(int accountNumber)
        {

        }
        public void Execute(int accountNumber, decimal amount)
        {
            _bankDatabaseService.Debit(accountNumber, amount);
        }
    }
}
