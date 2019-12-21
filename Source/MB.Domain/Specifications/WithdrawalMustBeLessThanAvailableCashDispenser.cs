using MB.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Specifications
{
    public class WithdrawalMustBeLessThanAvailableCashDispenser
    {
        /// <summary>
        /// UC003 – Sacar Dinheiro da Conta
        /// Fluxo de Exceção 01 - ATM não possui cédulas suficientes
        /// Repositório: \ProjetoBlocoInfnet_MoneyBank\Documentos\Caso_Uso
        /// </summary>
        public bool IsSatisfiedBy(Amount withdrawalAmount, Amount _cashDispenser)
        {
            return withdrawalAmount.Value <= _cashDispenser.Value;
        }
    }
}
