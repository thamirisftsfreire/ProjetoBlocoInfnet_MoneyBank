using MB.Domain.Aggregations.AccountAggregate.Entities;
using MB.Domain.Aggregations.AccountAggregate.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Aggregations.AccountAggregate.Services
{
    public class DepositService : TransactionService, IDepositService
    {
        private readonly IBankDataBaseService _bankDatabaseService;
        DepositService(IBankDataBaseService bankDatabaseService)
        {
            _bankDatabaseService = bankDatabaseService;
        }
        public override void Execute()
        {
            _bankDatabaseService.Credit(AccountNumber, Amount);
        }
    }
}
