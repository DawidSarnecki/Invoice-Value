using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TableInvoice.Models;

namespace TableInvoice.UnitTests
{
    [TestClass]
    public class UnitTests
    {
        private IDiscountHelper getTestOject()
        {
            return new MinimumDiscounterHelper();
        }

        [TestMethod]
        public void Discount_above_100()
        {
            //prepare UT
            IDiscountHelper target = getTestOject();
            decimal total = 200;

            //execute
            var discountedTotal = target.ApplyDiscount(total);

            //asertions
            Assert.AreEqual(total * 0.9M, discountedTotal);
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            //prepare UT
            IDiscountHelper target = getTestOject();

            //execute
            decimal TenDiscount = target.ApplyDiscount(10);
            decimal HundredDiscount = target.ApplyDiscount(100);
            decimal FiftyDiscount = target.ApplyDiscount(50);

            //asertions
            Assert.AreEqual(5, TenDiscount,"Incorrect discount 10");
            Assert.AreEqual(95, HundredDiscount, "Incorrect discount 100");
            Assert.AreEqual(45, FiftyDiscount, "Incorrect discount 50");
        }

        [TestMethod]
        public void Discount_Less_Than_10()
        {
            //prepare UT
            IDiscountHelper target = getTestOject();

            //execute
            decimal discount5 = target.ApplyDiscount(5);
            decimal discount0 = target.ApplyDiscount(0);

            //asertions
            Assert.AreEqual(5, discount5);
            Assert.AreEqual(0, discount0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative_Total()
        {
            //prepare UT
            IDiscountHelper target = getTestOject();

            //execute
            target.ApplyDiscount(-1);
            
        }
    }
}
