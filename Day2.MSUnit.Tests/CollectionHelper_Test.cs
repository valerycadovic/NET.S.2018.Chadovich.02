using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Day2.MSUnit.Tests
{
    [TestClass]
    public class CollectionHelper_Test
    {
        [TestMethod]
        public void Can_FilterDigit()
        {
            int[] expectation = { 1, 11, 12, 121, -1 };

            var actual = new int[] { 1, 2, 11, 12, 121, -1, 4, 6 }.FilterDigit(1);

            CollectionAssert.AreEqual(expectation, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Can_FilterDigit_Throw_IfNull()
        {
            CollectionHelper.FilterDigit(null, 1);
        }

        [TestMethod]
        public void Can_Filter()
        {
            double[] expectation = { 1.0, 11.2, 12.4, 121.5, -1.33 };

            var actual = new double[] { 1.0, 2.34, 11.2, 12.4, 121.5, -1.33, 4.3, 6.6 }
            .Filter(n => n.ToString().Contains('1'))
            .ToArray();

            CollectionAssert.AreEqual(expectation, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Can_Filter_Throw_IfNull()
        {
            var a = new double[] { 0 }.Filter(null).First();
        }
    }
}
