using MB.Domain.Entities;
using MB.Domain.Interfaces.Repository;
using MB.Domain.Specifications;
using MB.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Test.Specification
{
    [TestClass]
    public class WithdrawalMustBeLessThanAccountBalanceUTest
    {
        public Account Account { get; set; }
        public WithdrawalMustBeLessThanAccountBalance withdrawalMustBeLessThanAccountBalance { get; set; }

        [TestMethod]
        public void WithdrawalMustBeLessThanAccountBalance_Assert_True()
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
            withdrawalMustBeLessThanAccountBalance = new WithdrawalMustBeLessThanAccountBalance(stubRepo.Object);
            Assert.IsTrue(withdrawalMustBeLessThanAccountBalance.IsSatisfiedBy(Account.Id, new Amount("USD", 200)));
        }
        [TestMethod]
        public void WithdrawalMustBeLessThanAccountBalance_Assert_False()
        {
            Account = new Account()
            {
                PIN = 90565,
                Id = 27056,
                TotalAmount = new Amount("USD", 100),
                ClientId = 22
            };
            var stubRepo = new Mock<IAccountRepository>();
            stubRepo.Setup(s => s.FindAsync(27056)).ReturnsAsync(Account);
            withdrawalMustBeLessThanAccountBalance = new WithdrawalMustBeLessThanAccountBalance(stubRepo.Object);
            Assert.IsFalse(withdrawalMustBeLessThanAccountBalance.IsSatisfiedBy(Account.Id, new Amount("USD", 200)));
        }
    }
}
