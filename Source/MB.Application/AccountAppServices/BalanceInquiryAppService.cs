using MB.Domain.Interfaces.Services;
using MB.Domain.Services;
using MB.Domain.Entities;
using System;
using MB.Application.Interfaces;
using MB.Data.Interfaces;
using MB.Domain.ValueObjects;

namespace MB.Application.AccountAppServices
{
    public class BalanceInquiryAppService : ApplicationService, IBalanceInquiryAppService
    {
        private readonly IBalanceInquiryService _balanceInquiryService;
        public BalanceInquiryAppService(IBalanceInquiryService balanceInquiryService, IUnitOfWork uow) 
            : base(uow)
        {
            _balanceInquiryService = balanceInquiryService;
        }
        public void Execute(int accountNumber)
        {
            BeginTransaction();
            _balanceInquiryService.Execute(accountNumber);
            Commit();
        }

        public void Execute(int accountNumber, Amount amount)
        {
            
        }
    }
}
