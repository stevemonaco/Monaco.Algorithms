using System;
using System.Collections.Generic;
using System.Linq;
using Monaco.Algorithms.Extensions;
using Monaco.Algorithms.UnitTests.AssertHelpers;
using NUnit.Framework;

namespace Monaco.Algorithms.UnitTests.ExtensionsTests
{
    [TestFixture]
    class ListExtensionTests
    {
        [Test]
        public void RandomShuffle_AfterShuffle_ContainsAllElements()
        {
            var list = Enumerable.Range(0, 20).ToList();
            var shuffled = Enumerable.Range(0, 20).ToList();

            shuffled.RandomShuffle(new Random(0x12345678));

            ListAssert.ContainsSameItems(list, shuffled);
        }

        [TestCase(-1, 3)]
        [TestCase(6, 3)]
        [TestCase(0, -1)]
        [TestCase(0, 6)]
        public void Swap_IndexOutOfRange_ThrowsOutOfRangeException(int firstIndex, int secondIndex)
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };

            Assert.Throws<ArgumentOutOfRangeException>(() => list.Swap(firstIndex, secondIndex));
        }

        [TestCase(0, 5)]
        [TestCase(2, 3)]
        public void Swap_SwapsCorrectly(int firstIndex, int secondIndex)
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };
            var firstExpected = list[secondIndex];
            var secondExpected = list[firstIndex];

            list.Swap(firstIndex, secondIndex);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(firstExpected, list[firstIndex]);
                Assert.AreEqual(secondExpected, list[secondIndex]);
            });
        }
    }
}
