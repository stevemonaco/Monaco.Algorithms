using System;
using System.Collections.Generic;
using System.Linq;
using Monaco.Algorithms.Sorting;
using Monaco.Algorithms.UnitTests.AssertHelpers;
using NUnit.Framework;

namespace Monaco.Algorithms.UnitTests.Sorting
{
    [TestFixture]
    class SelectionSorterTests
    {
        [TestCase]
        public void SelectionSorter_EmptyList_RemainsEmptyList()
        {
            var expected = new List<string>();
            var sorter = new SelectionSorter<string>();

            var actual = new List<string>();
            sorter.Sort(actual);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void SelectionSorter_NullList_ThrowsNullReferenceException()
        {
            var sorter = new SelectionSorter<string>();

            Assert.Throws<NullReferenceException>(() => sorter.Sort(null));
        }

        [TestCaseSource(typeof(SortTestCases), "StringSortCases")]
        public void SelectionSorter_SortStringsAscending_SortsCorrectly(IList<string> actual)
        {
            var sorter = new SelectionSorter<string>();

            sorter.Sort(actual, SortOrder.Ascending);

            SortAssert.IsSortedAscending(actual, Comparer<string>.Default);
        }

        [TestCaseSource(typeof(SortTestCases), "StringSortCases")]
        public void SelectionSorter_SortStringsDescending_SortsCorrectly(IList<string> actual)
        {
            var sorter = new SelectionSorter<string>();

            sorter.Sort(actual, SortOrder.Descending);

            SortAssert.IsSortedDescending(actual, Comparer<string>.Default);
        }
    }
}
