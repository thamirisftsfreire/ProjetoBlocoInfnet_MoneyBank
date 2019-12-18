using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Aggregations.AccountAggregate.Services
{
    public class AccountService
    {
        public double GetAvailableBalance() { return 0; } //retorna o saldo disponível na conta;
        public double GetTotalBalance() { return 0; } // retorna o saldo total da conta;
        public void Credit() {  } //credita uma quantia na conta especificada;
        public void Debit() {  } //debita uma quantia na conta especificada;
        public int GetAccountNumber() { return 0; } // retorna o número da conta
    }
}
