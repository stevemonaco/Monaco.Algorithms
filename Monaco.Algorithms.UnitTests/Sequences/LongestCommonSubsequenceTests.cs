using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Monaco.Algorithms.Sequences;

namespace Monaco.Algorithms.UnitTests.Sequences
{
    [TestFixture]
    class LongestCommonSubsequenceTests
    {
        [TestCaseSource(typeof(LongestCommonSubsequenceTestCases), "LcsLengthCases")]
        public void LcsLengthRecursive_ValidStrings_ReturnsExpected(string s1, string s2, int expected)
        {
            int actual = LongestCommonSubsequence.LcsLengthRecursive(s1, s2);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(LongestCommonSubsequenceTestCases), "LcsLengthCases")]
        public void LcsLengthMemo_ValidStrings_ReturnsExpected(string s1, string s2, int expected)
        {
            int actual = LongestCommonSubsequence.LcsLengthMemo(s1, s2);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(LongestCommonSubsequenceTestCases), "LcsLengthCases")]
        public void LcsLengthDynamic_ValidStrings_ReturnsExpected(string s1, string s2, int expected)
        {
            int actual = LongestCommonSubsequence.LcsLengthDynamic(s1, s2);
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(LongestCommonSubsequenceTestCases), "LcsStringCases")]
        public void LcsStringDynamic(string s1, string s2, string expected)
        {
            string actual = LongestCommonSubsequence.LcsStringDynamic(s1, s2);
            Assert.AreEqual(expected, actual);
        }
    }
}
