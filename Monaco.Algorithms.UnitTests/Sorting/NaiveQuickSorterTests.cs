using System;
using System.Collections.Generic;
using NUnit.Framework;
using Monaco.Algorithms.Sorting;
using Monaco.Algorithms.UnitTests.AssertHelpers;

namespace Monaco.Algorithms.UnitTests.Sorting
{
    [TestFixture]
    class NaiveQuickSorterTests
    {
        [TestCase]
        public void NaiveQuickSorter_EmptyList_RemainsEmptyList()
        {
            var expected = new List<string>();
            var sorter = new NaiveQuickSorter<string>();

            var actual = new List<string>();
            sorter.Sort(actual);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void NaiveQuickSorter_NullList_ThrowsNullReferenceException()
        {
            var sorter = new NaiveQuickSorter<string>();

            Assert.Throws<NullReferenceException>(() => sorter.Sort(null));
        }

        [TestCaseSource(typeof(SortTestCases), "StringSortCases")]
        public void NaiveQuickSorter_SortStringsAscending_SortsCorrectly(IList<string> actual)
        {
            var sorter = new NaiveQuickSorter<string>();

            sorter.Sort(actual, SortOrder.Ascending);

            SortAssert.IsSortedAscending(actual, Comparer<string>.Default);
        }

        [TestCaseSource(typeof(SortTestCases), "StringSortCases")]
        public void NaiveQuickSorter_SortStringsDescending_SortsCorrectly(IList<string> actual)
        {
            var sorter = new NaiveQuickSorter<string>();

            sorter.Sort(actual, SortOrder.Descending);

            SortAssert.IsSortedDescending(actual, Comparer<string>.Default);
        }
    }
}
