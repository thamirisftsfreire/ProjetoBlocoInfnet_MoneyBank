using MB.Domain.Entities;
using MB.Domain.Interfaces.Services;
using MB.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Services
{
    public class DepositService : IDepositService
    {
        private readonly IBankDataBaseService _bankDatabaseService;
        public DepositService(IBankDataBaseService bankDatabaseService)
        {
            _bankDatabaseService = bankDatabaseService;
        }

        public void Execute(int accountNumber, Amount amount)
        {
            _bankDatabaseService.Credit(accountNumber, amount);
        }

        public Amount Execute(int accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
