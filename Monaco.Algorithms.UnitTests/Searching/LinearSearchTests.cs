using System;
using System.Collections.Generic;
using NUnit.Framework;
using Monaco.Algorithms.Searching;

namespace Monaco.Algorithms.UnitTests.Searching
{
    class LinearSearchTests
    {
        [TestCaseSource(typeof(SearchTestCases), "FindFirstItemIntTestCases")]
        public void FindFirstItem_Int_ReturnsExpected(IList<int> items, int searchItem, int expected)
        {
            int actual = LinearSearch.FindFirstItem(items, searchItem);

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(SearchTestCases), "FindFirstSequenceIntTestCases")]
        public void FindFirstSequence_Int_ReturnsExpected(IList<int> items, IList<int> searchItem, int expected)
        {
            int actual = LinearSearch.FindFirstSequence(items, searchItem);

            Assert.AreEqual(expected, actual);
        }
    }
}
