using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day2;

namespace Day2.MSUnit.Tests
{
    [TestClass]
    public class BitAlgorithms_Test
    {
        [TestMethod]
        public void Can_Insert()
        {
            var a = BitAlgorithms.InsertNumber(15, 15, 0, 0);
            var b = BitAlgorithms.InsertNumber(15, 8, 0, 0);
            var c = BitAlgorithms.InsertNumber(15, 8, 3, 8);

            Assert.AreEqual(15, a);
            Assert.AreEqual(9, b);
            Assert.AreEqual(120, c);
        }
    }
}
