using MB.Domain.Entities;
using MB.Domain.Specifications;
using MB.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Test.Specification
{
    [TestClass]
    public class AccountMustBeFiveCharactersUTest
    {

        [TestMethod]
        public void AccountMustBeFiveCharacters_Assert_True()
        {
            Assert.IsTrue(new AccountMustBeFiveCharacters().IsSatisfiedBy(12345));
        }
        [TestMethod]
        public void AccountMustBeFiveCharacters_GreaterThanFive_Assert_True()
        {
            Assert.IsFalse(new AccountMustBeFiveCharacters().IsSatisfiedBy(123456));
        }
        [TestMethod]
        public void AccountMustBeFiveCharacters_LessThanFive_Assert_True()
        {
            Assert.IsFalse(new AccountMustBeFiveCharacters().IsSatisfiedBy(45));
        }
    }
}
