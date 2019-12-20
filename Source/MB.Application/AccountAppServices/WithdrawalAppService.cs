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
        public WithdrawalAppService(IWithdrawalService withdrawalService, IUnitOfWork uow)
            : base(uow)
        {
            _withdrawalService = withdrawalService;
        }
        public void Execute(int accountNumber, Amount amount)
        {
            _withdrawalService.Execute(accountNumber, amount);
        }

        public void Execute(int accountNumber)
        {

        }
    }
}
