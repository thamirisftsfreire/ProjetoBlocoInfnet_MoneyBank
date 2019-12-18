using System;
using System.Collections.Generic;
using System.Text;
using MB.Domain.Aggregations.AccountAggregate.Entities;

namespace MB.Domain.Aggregations.AccountAggregate.Services
{
    public class BankDatabaseService
    {
        private Account GetAccount(int accountNumber) { return null; } 
        // recupera o objeto que contém o número da conta especificado como parâmetro;
        public Boolean AuthenticateUser(int intuserAccountNumber, int intuserPIN) { return true; } 
        //que determina se o número da conta e PIN correspondem a uma conta do banco;
        public Double GetAvailableBalance(int intuserAccountNumber) { return 0; }
        //retorna o saldo disponível na conta;
        public Double GetTotalBalance(int intuserAccountNumber) { return 0; }
        // que retorna o saldo total da conta;
        public void Credit(int intuserAccountNumber, double doubleamount) { }
        // que credita uma quantia na conta especificada;
        public void Debit(int intuserAccountNumber, double doubleamount) { }
        //que debita uma quantia na conta especificada;
    }
}
