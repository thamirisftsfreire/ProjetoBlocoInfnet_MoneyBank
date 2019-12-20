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
    public class WithdrawalServiceUTest
    {
        public Account Account { get; set; }
        public WithdrawalService WithdrawalService { get; set; }
        public BalanceInquiryService BalanceInquiryService { get; set; }

        [TestMethod]
        public void WithdrawalServiceUTest_Assert_True()
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
            WithdrawalService = new WithdrawalService(bankDataBaseService, stubRepo.Object);
            BalanceInquiryService = new BalanceInquiryService(bankDataBaseService);
            WithdrawalService.Execute(Account.Id, new Amount("USD", 100));
            Assert.IsTrue(BalanceInquiryService.Execute(27056) == new Amount("USD", 400));
        }
        [TestMethod]
        public void WithdrawalServiceUTest_Assert_False()
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
            WithdrawalService = new WithdrawalService(bankDataBaseService, stubRepo.Object);
            BalanceInquiryService = new BalanceInquiryService(bankDataBaseService);
            WithdrawalService.Execute(Account.Id, new Amount("USD", 100));
            Assert.IsFalse(BalanceInquiryService.Execute(27056) == new Amount("USD", 100));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Account not found!")]
        public void WithdrawalServiceUTest_AccountNotFound_Assert_Exception()
        {
            Account = new Account();
            var stubRepo = new Mock<IAccountRepository>();
            IBankDataBaseService bankDataBaseService = new BankDataBaseService(stubRepo.Object);
            WithdrawalService = new WithdrawalService(bankDataBaseService, stubRepo.Object);
            WithdrawalService.Execute(27056, new Amount("USD", 1100));
        }
    }
}
