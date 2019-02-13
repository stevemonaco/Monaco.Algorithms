using System;
using System.Collections.Generic;
using System.Linq;
using Monaco.Algorithms.Searching;
using NUnit.Framework;

namespace Monaco.Algorithms.UnitTests.Searching
{
    [TestFixture]
    class KmpStringMatcherTests
    {
        [TestCaseSource(typeof(StringMatcherCases), "FindFirstTestCases")]
        public void FindFirst_ReturnsExpected(string text, string pattern, int startIndex, int expected)
        {
            var kmp = new KmpStringMatcher(pattern);
            int actual = kmp.FindFirst(text, startIndex);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(StringMatcherCases), "FindAllTestCases")]
        public void FindAll_ReturnsExpected(string text, string pattern, int startIndex, IEnumerable<int> expected)
        {
            var kmp = new KmpStringMatcher(pattern);
            var actual = kmp.FindAll(text, startIndex).ToList();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase("", typeof(ArgumentException))]
        [TestCase(null, typeof(NullReferenceException))]
        public void SetPattern_InvalidPattern_ThrowsException(string pattern, Type expected)
        {
            var kmp = new KmpStringMatcher();
            Assert.Throws(expected, () => { kmp.SetPattern(pattern); });
        }
    }
}
