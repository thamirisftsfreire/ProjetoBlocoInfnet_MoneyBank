using MB.Domain.Aggregations.AccountAggregate.Entities;
using MB.Domain.Aggregations.AccountAggregate.Interfaces.Services;
using MB.Domain.Aggregations.AccountAggregate.Validations;
using MB.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Aggregations.AccountAggregate.Services
{
    public class AccountService : IAccountService
    {
        protected readonly IAccountRepository _accountRepository;
        protected Account _account;
        public AccountService(IAccountRepository accountRepository, Account account)
        {
            _accountRepository = accountRepository;
            _account = account;
        }
        /// <summary>
        /// Retorna o saldo disponível na conta.
        /// </summary>
        /// <returns></returns>
        Decimal IAccountService.GetAvailableBalance(int accountId) 
        {
            _account = _accountRepository.FindAsync(accountId).Result;
            return _account.TotalBalance; 
        }
        /// <summary>
        /// Retorna o saldo total da conta
        /// </summary>
        /// <returns></returns>
        Decimal IAccountService.GetTotalBalance(int accountId)
        {
            _account = _accountRepository.FindAsync(accountId).Result;
            return _account.TotalBalance;
        }
        /// <summary>
        /// Credita uma quantia na conta especificada
        /// </summary>
        void IAccountService.Credit(int accountId, Decimal ValorCredito) 
        {
            _account = _accountRepository.FindAsync(accountId).Result;
            _account.TotalBalance = _account.TotalBalance + ValorCredito;
            _accountRepository.Update(_account);
        }
        /// <summary>
        /// Debita uma quantia na conta especificada
        /// </summary>
        void IAccountService.Debit(int accountId, Decimal ValorDebito) 
        {
            _account = _accountRepository.FindAsync(accountId).Result;
            _account.TotalBalance = _account.TotalBalance - ValorDebito;
            _accountRepository.Update(_account);
        }
        /// <summary>
        /// retorna o número da conta
        /// </summary>
        /// <returns></returns>
        int IAccountService.GetAccountNumber(int accountId) 
        {
            var account = _accountRepository.FindAsync(accountId);
            if (account == null || account.Result.Id == 0)
                throw new Exception("No record found for given parameters");
            return account.Result.Id;
        }

        public Boolean ValidatePIN(Account account)
        {
            return new AuthenticationValidation(_accountRepository).IsSatisfiedBy(account);
        }

    }
}
