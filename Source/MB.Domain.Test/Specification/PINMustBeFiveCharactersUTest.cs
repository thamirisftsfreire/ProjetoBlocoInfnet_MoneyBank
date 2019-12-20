using MB.Domain.Specifications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MB.Domain.Test.Specification
{
    [TestClass]
    public class PINMustBeFiveCharactersUTest
    {
        [TestMethod]
        public void PINMustBeFiveCharacters_Assert_True()
        {
            Assert.IsTrue(new PINMustBeFiveCharacters().IsSatisfiedBy(12345));
        }
        [TestMethod]
        public void PINMustBeFiveCharacters_GreaterThanFive_Assert_True()
        {
            Assert.IsFalse(new PINMustBeFiveCharacters().IsSatisfiedBy(123456));
        }
        [TestMethod]
        public void PINMustBeFiveCharacters_LessThanFive_Assert_True()
        {
            Assert.IsFalse(new PINMustBeFiveCharacters().IsSatisfiedBy(54));
        }
    }
}
