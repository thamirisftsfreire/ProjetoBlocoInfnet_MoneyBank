using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Specifications
{
    public class AccountMustBeFiveCharacters
    {
        /// <summary>
        /// UC001 – Autenticar Usuário
        /// a.1)	Detalhamento dos Atributos - Regras - Número de Conta
        /// Repositório: \ProjetoBlocoInfnet_MoneyBank\Documentos\Caso_Uso
        /// </summary>
        public bool IsSatisfiedBy(int accountNumber)
        {
            return accountNumber.ToString().Length == 5;
        }
    }
}
