using MB.Domain.Aggregations.AccountAggregate.Entities;
using MB.Domain.Aggregations.AccountAggregate.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Aggregations.AccountAggregate.Services
{
    public class BalanceInquiryService : TransactionService, IBalanceInquiryService
    {
        private readonly IBankDataBaseService _bankDatabaseService;
        BalanceInquiryService(IBankDataBaseService bankDatabaseService)
        {
            _bankDatabaseService = bankDatabaseService;
        }
        public override void Execute()
        {
            _bankDatabaseService.GetTotalBalance(AccountNumber);
        }
    }
}
