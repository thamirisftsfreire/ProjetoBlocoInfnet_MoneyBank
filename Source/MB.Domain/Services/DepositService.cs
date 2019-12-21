using MB.Domain.Entities;
using MB.Domain.Interfaces.Services;
using MB.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Services
{
    public class DepositService : IDepositService
    {
        private readonly IBankDataBaseService _bankDatabaseService;
        public DepositService(IBankDataBaseService bankDatabaseService)
        {
            _bankDatabaseService = bankDatabaseService;
        }

        /// <summary>
        /// Debita uma quantia na conta especificada
        /// REQ003_Sacar Dinheiro da Conta
        /// Repositório: \ProjetoBlocoInfnet_MoneyBank\Documentos\
        /// </summary>
        public void Execute(int accountNumber, Amount amount)
        {
            _bankDatabaseService.Credit(accountNumber, amount);
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
