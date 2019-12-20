using MB.Domain.Entities;
using MB.Domain.Interfaces.Repository;
using MB.Domain.Interfaces.Services;
using MB.Domain.Services;
using MB.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace MB.Domain.Test.Services
{
    [TestClass]
    public class DepositServiceUTest
    {
        public Account Account { get; set; }
        public DepositService DepositService { get; set; }
        public BalanceInquiryService BalanceInquiryService { get; set; }

        [TestMethod]
        public void DepositService_Assert_True()
        {
            Account = new Account()
            {
                PIN = 90565,
                Id = 27056,
                TotalAmount = new Amount("USD", 500),
                ClientId = 22
            };


            var stubRepo = new Mock<IAccountRepository>();     
            stubRepo.Setup(s => s.FindAsync(27056)).ReturnsAsync(Account);
            IBankDataBaseService bankDataBaseService = new BankDataBaseService(stubRepo.Object);
            DepositService = new DepositService(bankDataBaseService);
            BalanceInquiryService = new BalanceInquiryService(bankDataBaseService);
            DepositService.Execute(Account.Id, new Amount("USD", 600));
            Assert.IsTrue(BalanceInquiryService.Execute(27056) == new Amount("USD", 1100));
        }
        [TestMethod]
        public void DepositService_Assert_False()
        {
            Account = new Account()
            {
                PIN = 90565,
                Id = 27056,
                TotalAmount = new Amount("USD", 600),
                ClientId = 22
            };


            var stubRepo = new Mock<IAccountRepository>();
            stubRepo.Setup(s => s.FindAsync(27056)).ReturnsAsync(Account);
            IBankDataBaseService bankDataBaseService = new BankDataBaseService(stubRepo.Object);
            DepositService = new DepositService(bankDataBaseService);
            BalanceInquiryService = new BalanceInquiryService(bankDataBaseService);
            DepositService.Execute(Account.Id, new Amount("USD", 600));
            Assert.IsFalse(BalanceInquiryService.Execute(27056) == new Amount("USD", 1100));
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Account not found!")]
        public void DepositService_AccountNotFound_Assert_Exception()
        {
            Account = new Account();
            var stubRepo = new Mock<IAccountRepository>();
            IBankDataBaseService bankDataBaseService = new BankDataBaseService(stubRepo.Object);
            DepositService = new DepositService(bankDataBaseService);
            DepositService.Execute(27056, new Amount("USD", 1100));
        }
    }
}
