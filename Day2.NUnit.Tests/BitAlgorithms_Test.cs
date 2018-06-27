using System;
using NUnit.Framework;
using Day2;

namespace Day2.NUnit.Tests
{
    [TestFixture]
    public class BitAlgorithms_Test
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(15, 8, 0, 0, ExpectedResult = 9)]
        [TestCase(15, 8, 3, 8, ExpectedResult = 120)]
        public int Can_Insert(int source, int drain, int start, int end) => BitAlgorithms.InsertNumber(source, drain, start, end);

        [Test]
        public void Insert_Throws_If_StartNotInRange() => Assert.Throws<ArgumentOutOfRangeException>(
            () => BitAlgorithms.InsertNumber(8, 15, -1, 5));

        [Test]
        public void Insert_Throws_If_EndNotInRange() => Assert.Throws<ArgumentOutOfRangeException>(
            () => BitAlgorithms.InsertNumber(8, 15, 1, 35));

        [Test]
        public void Insert_Throws_If_EndLessThanStart() => Assert.Throws<InvalidOperationException>(
            () => BitAlgorithms.InsertNumber(8, 15, 10, 9));

        [TestCase(-8, 15, 0, 1)]
        [TestCase(8, -15, 0, 1)]
        [TestCase(-8, -15, 0, 1)]
        public void Insert_Throws_If_Negative(int source, int drain, int start, int end) 
            => Assert.Throws<InvalidOperationException>(
            () => BitAlgorithms.InsertNumber(source, drain, start, end));

    }
}
