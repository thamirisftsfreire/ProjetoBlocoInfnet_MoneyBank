using MB.Application.Interfaces;
using MB.Data.Interfaces;
using MB.Domain.Entities;
using MB.Domain.Interfaces.Services;
using MB.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Application.AccountAppServices
{
    public class WithdrawalAppService : ApplicationService, IWithdrawalAppService
    {
        private readonly IWithdrawalService _withdrawalService;
        private readonly ICashDispenserAppService _cashDispenserAppService;
        public WithdrawalAppService(IWithdrawalService withdrawalService, IUnitOfWork uow)
            : base(uow)
        {
            _withdrawalService = withdrawalService;
        }
        public void Execute(int accountNumber, Amount amount)
        {
            BeginTransaction();

            if (_cashDispenserAppService.IsSufficientCashAvailable(amount))
                throw new Exception("Not enough money in the banknote dispenser.");
            
            _withdrawalService.Execute(accountNumber, amount);

            if(!_cashDispenserAppService.DispenseCash(amount))
                throw new Exception();

            Commit();
        }

        public void Execute(int accountNumber)
        {

        }
    }
}
