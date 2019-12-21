using MB.Domain.Entities;
using MB.Domain.Interfaces.Services;
using MB.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Services
{
    public class BalanceInquiryService : IBalanceInquiryService
    {
        private readonly IBankDataBaseService _bankDatabaseService;
        public BalanceInquiryService(IBankDataBaseService bankDatabaseService)
        {
            _bankDatabaseService = bankDatabaseService;
        }
        /// <summary>
        /// Retorna o saldo total da conta
        /// REQ002_Visualizar Saldo da Conta 
        /// Repositório: \ProjetoBlocoInfnet_MoneyBank\Documentos\
        /// </summary>
        public Amount Execute(int accountNumber)
        {
            return _bankDatabaseService.GetTotalBalance(accountNumber);
        }
        /// <summary>
        /// Não implementado
        /// </summary>
        public void Execute(int accountNumber, Amount amount)
        {
            throw new NotImplementedException();
        }
    }
}
