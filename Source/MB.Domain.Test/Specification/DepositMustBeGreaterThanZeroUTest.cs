using MB.Domain.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Test.Specification
{
    [TestClass]
    public class DepositMustBeGreaterThanZeroUTest
    {
        [TestMethod]
        public void DepositMustBeGreaterThanZero_Assert_True()
        {
            Assert.IsTrue(new DepositMustBeGreaterThanZero().IsSatisfiedBy(5));
        }
        [TestMethod]
        public void DepositMustBeGreaterThanZero_EqualToZero_Assert_True()
        {
            Assert.IsFalse(new DepositMustBeGreaterThanZero().IsSatisfiedBy(0));
        }
        [TestMethod]
        public void DepositMustBeGreaterThanZero_LessThanZero_Assert_True()
        {
            Assert.IsFalse(new DepositMustBeGreaterThanZero().IsSatisfiedBy(-1));
        }
    }
}
