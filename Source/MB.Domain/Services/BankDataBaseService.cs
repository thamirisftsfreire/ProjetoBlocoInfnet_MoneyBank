using System;
using System.Collections.Generic;
using System.Text;
using MB.Domain.Entities;
using MB.Domain.Interfaces.Services;
using MB.Domain.Interfaces.Repository;

namespace MB.Domain.Services
{
    public class BankDataBaseService : AccountService, IBankDataBaseService
    {
        public BankDataBaseService(IAccountRepository accountRepository)
            : base(accountRepository)
        {

        }
        /// <summary>
        /// REQ001_Autenticar Usuário 
        /// Repositório: \ProjetoBlocoInfnet_MoneyBank\Documentos\
        /// </summary>
        public Boolean AuthenticateUser(Account account)
        {
            return ValidatePIN(account);
        }
    }
}
