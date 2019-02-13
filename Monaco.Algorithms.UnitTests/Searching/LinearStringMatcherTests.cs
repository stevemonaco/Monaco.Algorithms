using System;
using System.Collections.Generic;
using System.Linq;
using Monaco.Algorithms.Searching;
using NUnit.Framework;

namespace Monaco.Algorithms.UnitTests.Searching
{
    [TestFixture]
    class LinearStringMatcherTests
    {
        [TestCaseSource(typeof(StringMatcherTestCases), "FindFirstTestCases")]
        public void FindFirst_ReturnsExpected(string text, string pattern, int startIndex, int expected)
        {
            var matcher = new LinearStringMatcher();
            int actual = matcher.FindFirst(text, pattern, startIndex);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(StringMatcherTestCases), "FindAllTestCases")]
        public void FindAll_ReturnsExpected(string text, string pattern, int startIndex, IEnumerable<int> expected)
        {
            var matcher = new LinearStringMatcher();
            var actual = matcher.FindAll(text, pattern, startIndex).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
