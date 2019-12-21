using MB.Domain.Entities;
using MB.Domain.Interfaces.Repository;
using MB.Domain.ValueObjects;
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
        /// <summary>
        /// UC003 – Sacar Dinheiro da Conta
        /// Fluxo de Exceção 02 - Saldo de Conta insuficiente para saque
        /// Repositório: \ProjetoBlocoInfnet_MoneyBank\Documentos\Caso_Uso
        /// </summary>
        public bool IsSatisfiedBy(int accountNumber, Amount withdrawalAmount)
        {
            var _account = _accountRepository.FindAsync(accountNumber).Result;
            return withdrawalAmount.Value <= _account.TotalAmount.Value;
        }
    }
}
