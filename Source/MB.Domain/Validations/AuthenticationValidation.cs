using MB.Domain.Entities;
using MB.Domain.Specifications;
using MB.Domain.Interfaces.Repository;
using System;
using System.Security.Cryptography;
using MB.CrossCutting.Tools;

namespace MB.Domain.Validations
{
    public class AuthenticationValidation
    {
        private readonly IAccountRepository _accountRepository;

        public AuthenticationValidation(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public bool IsSatisfiedBy(Account account)
        {
            var _account = _accountRepository.FindAsync(account.Id).Result;

            if (_account == null || _account.Id == 0)
                return false;

            if (_account.Id != account.Id)
                return false;

            if (!new AccountMustBeFiveCharacters().IsSatisfiedBy(account.Id))
                return false;

            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            int decryptedDataPIN = Convert.ToInt32(RSACSP.RSADecrypt(_account.PIN, RSA.ExportParameters(true), false));
            int decryptedPINInfo = Convert.ToInt32(RSACSP.RSADecrypt(account.PIN, RSA.ExportParameters(true), false));


            if (!new PINMustBeFiveCharacters().IsSatisfiedBy(decryptedPINInfo))
                return false;

            if (decryptedDataPIN != decryptedPINInfo)
                return false;

            return true;
        }
    }
}
