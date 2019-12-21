using MB.Domain.ValueObjects;
using System;

namespace MB.Domain.Entities
{
    
    public class Account : BaseEntity<int>
    {
        /// <summary>
        /// BaseEntity - ID - Número de Conta do Cliente no Money Bank.
        /// </summary>

        /// <summary>
        /// Número de identificação pessoal do Cliente
        /// </summary>
        public int PIN { get; set; }
        /// <summary>
        /// Valor Total do Saldo da Conta
        /// </summary>
        public Amount TotalAmount { get; set; }
        /// <summary>
        /// Id do Cliente vinculado a conta
        /// </summary>
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
