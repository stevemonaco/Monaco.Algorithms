using System;
using System.Collections.Generic;
using System.Text;
using Monaco.Algorithms.Sorting;
using Monaco.Algorithms.UnitTests.AssertHelpers;
using NUnit.Framework;

namespace Monaco.Algorithms.UnitTests.Sorting
{
    [TestFixture]
    class BubbleSorterTests
    {
        [TestCase]
        public void BubbleSorter_EmptyList_RemainsEmptyList()
        {
            var expected = new List<string>();
            var sorter = new BubbleSorter<string>();

            var actual = new List<string>();
            sorter.Sort(actual);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void BubbleSorter_NullList_ThrowsNullReferenceException()
        {
            var sorter = new BubbleSorter<string>();

            Assert.Throws<NullReferenceException>(() => sorter.Sort(null));
        }

        [TestCaseSource(typeof(SortTestCases), "StringSortCases")]
        public void BubbleSorter_SortStringsAscending_SortsCorrectly(IList<string> actual)
        {
            var sorter = new BubbleSorter<string>();

            sorter.Sort(actual, SortOrder.Ascending);

            SortAssert.IsSortedAscending(actual, Comparer<string>.Default);
        }

        [TestCaseSource(typeof(SortTestCases), "StringSortCases")]
        public void BubbleSorter_SortStringsDescending_SortsCorrectly(IList<string> actual)
        {
            var sorter = new BubbleSorter<string>();

            sorter.Sort(actual, SortOrder.Descending);

            SortAssert.IsSortedDescending(actual, Comparer<string>.Default);
        }
    }
}
