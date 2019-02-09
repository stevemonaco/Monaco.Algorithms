using System.Collections.Generic;
using NUnit.Framework;
using Monaco.Algorithms.Sequences;

namespace Monaco.Algorithms.UnitTests.Sequences
{
    [TestFixture]
    class LongestIncreasingSubsequenceTests
    {
        [TestCase(new int[] { 10, 51, 75, 42 }, 3)]
        [TestCase(new int[] { 75, 10, 42, 51 }, 3)]
        [TestCase(new int[] { 75, 3, 8, 51, 15, 21 }, 4)]
        [TestCase(new int[] { 75 }, 1)]
        [TestCase(new int[] { }, 0)]
        public void LisLengthDynamic_ReturnsExpected(IList<int> items, int expected)
        {
            var actual = LongestIncreasingSubsequence<int>.LisLengthDynamic(items);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(LongestIncreasingSubsequenceTestCases), "LisListIntCases")]
        public void LisListDynamic_Int_ReturnsExpected(IList<int> items, IEnumerable<IEnumerable<int>> expected)
        {
            var actual = LongestIncreasingSubsequence<int>.LisListDynamic(items);
            Assert.AreEqual(expected, actual);
        }
    }
}
