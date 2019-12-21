using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Specifications
{
    public class PINMustBeFiveCharacters
    {
        /// <summary>
        /// UC001 – Autenticar Usuário
        /// a.1)	Detalhamento dos Atributos - Regras - PIN
        /// Repositório: \ProjetoBlocoInfnet_MoneyBank\Documentos\Caso_Uso
        /// </summary>
        public bool IsSatisfiedBy(int pin)
        {
            return pin.ToString().Length == 5;
        }
    }
}
