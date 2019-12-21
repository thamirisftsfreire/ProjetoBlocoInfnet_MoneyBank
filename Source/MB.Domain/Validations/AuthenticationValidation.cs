using MB.Domain.Entities;
using MB.Domain.Specifications;
using MB.Domain.Interfaces.Repository;

namespace MB.Domain.Validations
{
    public class AuthenticationValidation
    {
        private readonly IAccountRepository _accountRepository;

        public AuthenticationValidation(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        /// <summary>
        /// UC001 – Autenticar Usuário
        /// Fluxo de Exceção 01 - Número de Conta inválido ou PIN inválido
        /// Repositório: \ProjetoBlocoInfnet_MoneyBank\Documentos\Caso_Uso
        /// </summary>
        public bool IsSatisfiedBy(Account account)
        {
            var _account = _accountRepository.FindAsync(account.Id).Result;

            if (_account == null || _account.Id == 0)
                return false;

            if (_account.Id != account.Id)
                return false;

            if (!new AccountMustBeFiveCharacters().IsSatisfiedBy(account.Id))
                return false;

            if (!new PINMustBeFiveCharacters().IsSatisfiedBy(account.PIN))
                return false;

            if (_account.PIN != account.PIN)
                return false;

            return true;
        }
    }
}
