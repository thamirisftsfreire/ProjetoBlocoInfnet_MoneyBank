using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Entities
{
    public class Client : BaseEntity<int>
    {
        /// <summary>
        /// BaseEntity - ID - Identificador Único do cliente.
        /// </summary>
        
        /// <summary>
        /// Nome do cliente.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Data de Nascimento do cliente.
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Telefone do cliente.
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Endereço de E-mail do cliente.
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Endereço para acesso a Foto do cliente.
        /// </summary>
        public string PhotoUrl { get; set; }
        public Account Account { get; set; }
    }
}
