using MB.Domain.Entities;
using MB.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Services
{
    public class BalanceInquiryService : IBalanceInquiryService
    {
        private readonly IBankDataBaseService _bankDatabaseService;
        BalanceInquiryService(IBankDataBaseService bankDatabaseService)
        {
            _bankDatabaseService = bankDatabaseService;
        }
        public void Execute(int accountNumber)
        {
            _bankDatabaseService.GetTotalBalance(accountNumber);
        }

        public void Execute(int accountNumber, decimal amount)
        {
            
        }
    }
}
