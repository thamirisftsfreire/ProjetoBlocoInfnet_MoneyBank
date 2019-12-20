using MB.Domain.Entities;
using MB.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Specifications
{
    public class WithdrawalMustBeLessThanAccountBalance
    {
        private readonly IAccountRepository _accountRepository;
        public WithdrawalMustBeLessThanAccountBalance(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public bool IsSatisfiedBy(Account account, Decimal withdrawalAmount)
        {
            var _account = _accountRepository.FindAsync(account.Id).Result;
            return withdrawalAmount <= _account.TotalAmount.Value;
        }
    }
}
