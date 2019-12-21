using MB.Domain.Entities;
using MB.Domain.Interfaces.Services;
using MB.Domain.Validations;
using MB.Domain.Interfaces.Repository;
using MB.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Services
{
    public class AccountService : IAccountService
    {
        protected readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        /// <summary>
        /// Retorna o saldo disponível na conta.
        /// Método complementar para o REQ002_Visualizar Saldo da Conta 
        /// Repositório: \ProjetoBlocoInfnet_MoneyBank\Documentos\
        /// </summary>
        Amount IAccountService.GetAvailableBalance(int accountId) 
        {
            var _account = _accountRepository.FindAsync(accountId).Result;

            if (_account == null)
                throw new Exception("Account not found!");

            return new Amount("USD", _account.TotalAmount.Value);
        }
        /// <summary>
        /// Retorna o saldo total da conta
        /// Método complementar para o REQ002_Visualizar Saldo da Conta 
        /// Repositório: \ProjetoBlocoInfnet_MoneyBank\Documentos\
        /// </summary>
        Amount IAccountService.GetTotalBalance(int accountId)
        {
            var _account = _accountRepository.FindAsync(accountId).Result;

            if (_account == null)
                throw new Exception("Account not found!");

            return new Amount("USD",_account.TotalAmount.Value);
        }
        /// <summary>
        /// Credita uma quantia na conta especificada
        /// Método complementar para o REQ004_Depositar Dinheiro na Conta
        /// Repositório: \ProjetoBlocoInfnet_MoneyBank\Documentos\
        /// </summary>
        void IAccountService.Credit(int accountId, Decimal ValorCredito) 
        {
            var _account = _accountRepository.FindAsync(accountId).Result;
            
            if (_account == null)
                throw new Exception("Account not found!");

            _account.TotalAmount = new Amount("USD", _account.TotalAmount.Value + ValorCredito);
            _accountRepository.Update(_account);
        }
        /// <summary>
        /// Debita uma quantia na conta especificada
        /// Método complementar para o REQ003_Sacar Dinheiro da Conta
        /// Repositório: \ProjetoBlocoInfnet_MoneyBank\Documentos\
        /// </summary>
        void IAccountService.Debit(int accountId, Decimal ValorDebito) 
        {
            var _account = _accountRepository.FindAsync(accountId).Result;
            _account.TotalAmount = new Amount("USD", _account.TotalAmount.Value - ValorDebito);
            _accountRepository.Update(_account);
        }
        /// <summary>
        /// retorna o número da conta
        /// </summary>
        int IAccountService.GetAccountNumber(int accountId) 
        {
            var account = _accountRepository.FindAsync(accountId);
            if (account == null || account.Result.Id == 0)
                throw new Exception("No record found for given parameters");
            return account.Result.Id;
        }
        /// <summary>
        /// Método complementar para o REQ001_Autenticar Usuário 
        /// Repositório: \ProjetoBlocoInfnet_MoneyBank\Documentos\
        /// </summary>
        public Boolean ValidatePIN(Account account)
        {
            return new AuthenticationValidation(_accountRepository).IsSatisfiedBy(account);
        }

    }
}
