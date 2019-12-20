using MB.Domain.Entities;
using MB.Domain.Interfaces.Repository;
using MB.Domain.Interfaces.Services;
using MB.Domain.Services;
using MB.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace MB.Domain.Test.Services
{
    [TestClass]
    public class BalanceInquiryServiceUTest
    {

        public Account Account { get; set; }
        public BalanceInquiryService BalanceInquiryService { get; set; }

        [TestMethod]
        public void BalanceInquiry_Assert_True()
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
            BalanceInquiryService = new BalanceInquiryService(bankDataBaseService);         
            Assert.IsTrue(BalanceInquiryService.Execute(27056) == new Amount("USD", 500));
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Account not found!")]
        public void BalanceInquiry__AccountNotFound_Assert_Exception()
        {
            Account = new Account();
            var stubRepo = new Mock<IAccountRepository>();
            IBankDataBaseService bankDataBaseService = new BankDataBaseService(stubRepo.Object);
            BalanceInquiryService = new BalanceInquiryService(bankDataBaseService);
            BalanceInquiryService.Execute(27056);
        }
    }
}
