using System;
using System.Collections.Generic;
using System.Text;
using MB.Domain.Aggregations.AccountAggregate.Entities;
using MB.Domain.Aggregations.AccountAggregate.Interfaces.Services;
using MB.Domain.Interfaces.Repository;

namespace MB.Domain.Aggregations.AccountAggregate.Services
{
    public class BankDataBaseService : AccountService, IBankDataBaseService
    {
        public BankDataBaseService(IAccountRepository accountRepository, Account account)
            : base(accountRepository, account)
        {

        }
        public Boolean AuthenticateUser(Account account)
        {
            return ValidatePIN(account);
        }
    }
}
