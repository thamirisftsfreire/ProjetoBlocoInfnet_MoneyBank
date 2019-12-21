using MB.Domain.Entities;
using MB.Domain.Interfaces.Repository;
using MB.Domain.Interfaces.Services;
using MB.Domain.Specifications;
using MB.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Services
{
    public class WithdrawalService : IWithdrawalService
    {
        private readonly IBankDataBaseService _bankDatabaseService;
        private readonly IAccountRepository _accountRepository;
        public WithdrawalService(IBankDataBaseService bankDatabaseService, IAccountRepository accountRepository)
        {
            _bankDatabaseService = bankDatabaseService;
            _accountRepository = accountRepository;
        }
        /// <summary>
        /// Credita uma quantia na conta especificada
        /// REQ004_Depositar Dinheiro na Conta
        /// Repositório: \ProjetoBlocoInfnet_MoneyBank\Documentos\
        /// </summary>
        public void Execute(int accountNumber, Amount amount)
        {
            var resultAccount = _accountRepository.FindAsync(accountNumber).Result;
            if (resultAccount != null)
            {
                if (!new WithdrawalMustBeLessThanAccountBalance(_accountRepository)
                .IsSatisfiedBy(accountNumber, amount))
                    throw new Exception("Insufficient funds. Withdraw a smaller amount.");

                _bankDatabaseService.Debit(accountNumber, amount);
            }
            else
            {
                throw new Exception("Invalid Account.");
            }   
        }
        /// <summary>
        /// Não implementado
        /// </summary>
        public Amount Execute(int accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}
