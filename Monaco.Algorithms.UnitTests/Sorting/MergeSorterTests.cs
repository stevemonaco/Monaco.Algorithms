using System;
using System.Collections.Generic;
using Monaco.Algorithms.Sorting;
using Monaco.Algorithms.UnitTests.AssertHelpers;
using NUnit.Framework;

namespace Monaco.Algorithms.UnitTests.Sorting
{
    [TestFixture]
    class MergeSorterTests
    {
        [TestCase]
        public void NaiveMergeSorter_EmptyList_RemainsEmptyList()
        {
            var expected = new List<string>();
            var sorter = new MergeSorter<string>();

            var actual = new List<string>();
            sorter.Sort(actual);

            Assert.AreEqual(expected, actual);
        }

        [TestCase]
        public void NaiveMergeSorter_NullList_ThrowsNullReferenceException()
        {
            var sorter = new MergeSorter<string>();

            Assert.Throws<NullReferenceException>(() => sorter.Sort(null));
        }

        [TestCaseSource(typeof(SortTestCases), "StringSortCases")]
        public void NaiveMergeSorter_SortStringsAscending_SortsCorrectly(IList<string> actual)
        {
            var sorter = new MergeSorter<string>();

            sorter.Sort(actual, SortOrder.Ascending);

            SortAssert.IsSortedAscending(actual, Comparer<string>.Default);
        }

        [TestCaseSource(typeof(SortTestCases), "StringSortCases")]
        public void NaiveMergeSorter_SortStringsDescending_SortsCorrectly(IList<string> actual)
        {
            var sorter = new MergeSorter<string>();

            sorter.Sort(actual, SortOrder.Descending);

            SortAssert.IsSortedDescending(actual, Comparer<string>.Default);
        }
    }
}
