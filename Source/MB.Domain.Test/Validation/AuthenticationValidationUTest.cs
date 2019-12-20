using MB.Domain.Entities;
using MB.Domain.Interfaces.Repository;
using MB.Domain.Validations;
using MB.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Test.Validation
{
    [TestClass]
    public class AuthenticationValidationUTest
    {
        public Account Account { get; set; }
        public Account AccountBD { get; set; }
        public AuthenticationValidation authenticationValidation { get; set; }
        [TestMethod]
        public void AuthenticationValidation_Assert_True()
        {
            Account = new Account()
            {
                PIN = 90565,
                Id = 27056,
                TotalAmount = new Amount("USD", 500),
                ClientId = 22
            };
            AccountBD = new Account()
            {
                PIN = 90565,
                Id = 27056,
                TotalAmount = new Amount("USD", 500),
                ClientId = 22
            };
            var stubRepo = new Mock<IAccountRepository>();
            stubRepo.Setup(s => s.FindAsync(Account.Id)).ReturnsAsync(AccountBD);
            authenticationValidation = new AuthenticationValidation(stubRepo.Object);
            Assert.IsTrue(authenticationValidation.IsSatisfiedBy(Account));
        }
        [TestMethod]
        public void AuthenticationValidation_AccountNotFound_Assert_False()
        {
            Account = new Account()
            {
                PIN = 90565,
                Id = 27056,
                TotalAmount = new Amount("USD", 500),
                ClientId = 22
            };
            AccountBD = new Account();
            var stubRepo = new Mock<IAccountRepository>();
            stubRepo.Setup(s => s.FindAsync(27056)).ReturnsAsync(AccountBD);
            authenticationValidation = new AuthenticationValidation(stubRepo.Object);
            Assert.IsFalse(authenticationValidation.IsSatisfiedBy(Account));
        }
        [TestMethod]
        public void AuthenticationValidation_InvalidPIN_Assert_False()
        {
            Account = new Account()
            {
                PIN = 90565,
                Id = 27056,
                TotalAmount = new Amount("USD", 500),
                ClientId = 22
            };
            AccountBD = new Account()
            {
                PIN = 90566,
                Id = 27056,
                TotalAmount = new Amount("USD", 500),
                ClientId = 22
            };
            var stubRepo = new Mock<IAccountRepository>();
            stubRepo.Setup(s => s.FindAsync(27056)).ReturnsAsync(AccountBD);
            authenticationValidation = new AuthenticationValidation(stubRepo.Object);
            Assert.IsFalse(authenticationValidation.IsSatisfiedBy(Account));
        }
    }
}
