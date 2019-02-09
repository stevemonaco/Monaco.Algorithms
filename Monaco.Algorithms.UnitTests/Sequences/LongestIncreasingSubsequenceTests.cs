using System.Collections.Generic;
using NUnit.Framework;
using Monaco.Algorithms.Sequences;

namespace Monaco.Algorithms.UnitTests.Sequences
{
    [TestFixture]
    class LongestIncreasingSubsequenceTests
    {
        [TestCaseSource(typeof(LongestIncreasingSubsequenceTestCases), "LisLengthIntCases")]
        public void LisLengthDynamic_Int_ReturnsExpected(IList<int> items, int expected)
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
