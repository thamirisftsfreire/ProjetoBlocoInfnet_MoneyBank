using MB.Application.Interfaces;
using MB.Data.Interfaces;
using MB.Domain.Entities;
using MB.Domain.Interfaces.Services;
using MB.Domain.Services;
using MB.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Application.AccountAppServices
{
    public class DepositAppService : ApplicationService, IDepositAppService
    {
        private readonly IDepositService _depositService;
        public DepositAppService(IDepositService depositService, IUnitOfWork uow)
            : base(uow)
        {
            _depositService = depositService;
        }
        public void Execute(int accountNumber, Amount amount)
        {
            _depositService.Execute(accountNumber, amount);
        }

        public void Execute(int accountNumber)
        {
            
        }
    }
}
