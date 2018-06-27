using System;
using NUnit.Framework;
using Day2;
using System.Collections.Generic;

namespace Day2.NUnit.Tests
{
    [TestFixture]
    public class CollectionHelper_Test
    {
        [TestCase(new int[] { 1, 2, 11, 12, 121, -1, 4, 6 }, 1, ExpectedResult = new int[] { 1, 11, 12, 121, -1 })]
        public int[] Can_FilterDigit(int[] array, int digit) => array.FilterDigit(digit);

        [TestCase(new int[] { 1, 2, 11, 12, 121, -1, 4, 6 }, 10)]
        public void FilterDigit_Throws_InvalidOperationException(int[] array, int digit) => Assert.That(() =>
        array.FilterDigit(digit), Throws.TypeOf<InvalidOperationException>());

        [TestCase(new int[] { 1, 2, 11, 12, 121, -1, 4, 6 }, ExpectedResult = new int[] { 1, 11, 12, 121, -1 })]
        public IEnumerable<int> Can_FilterDigit(IEnumerable<int> array)
            => array.Filter(n => n.ToString().Contains("1"));
    }
}
