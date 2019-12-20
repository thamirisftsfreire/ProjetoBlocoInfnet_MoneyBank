using MB.Domain.Entities;
using MB.Domain.Interfaces.Services;
using MB.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Services
{
    public class BalanceInquiryService : IBalanceInquiryService
    {
        private readonly IBankDataBaseService _bankDatabaseService;
        public BalanceInquiryService(IBankDataBaseService bankDatabaseService)
        {
            _bankDatabaseService = bankDatabaseService;
        }
        public Amount Execute(int accountNumber)
        {
            return _bankDatabaseService.GetTotalBalance(accountNumber);
        }

        public void Execute(int accountNumber, Amount amount)
        {
            throw new NotImplementedException();
        }
    }
}
