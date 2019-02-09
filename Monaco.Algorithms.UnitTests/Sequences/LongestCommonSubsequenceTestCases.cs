using System.Collections.Generic;
using NUnit.Framework;

namespace Monaco.Algorithms.UnitTests.Sequences
{
    class LongestCommonSubsequenceTestCases
    {
        public static IEnumerable<TestCaseData> LcsStringCases
        {
            get
            {
                yield return new TestCaseData("Philosopher", "Phil", "Phil");
                yield return new TestCaseData("Philosopher", "sopher", "sopher");
                yield return new TestCaseData("Philosopher", "qsophm", "soph");
                yield return new TestCaseData("abi", "ABI", "");
                yield return new TestCaseData("qeBEio", "qeBEio", "qeBEio");
                yield return new TestCaseData("", "qeBEio", "");
                yield return new TestCaseData("qeBEio", "", "");
                yield return new TestCaseData("", "", "");
            }
        }

        public static IEnumerable<TestCaseData> LcsLengthCases
        {
            get
            {
                yield return new TestCaseData("Philosopher", "Phil", 4);
                yield return new TestCaseData("Philosopher", "sopher", 6);
                yield return new TestCaseData("Philosopher", "qsophm", 4);
                yield return new TestCaseData("abi", "ABI", 0);
                yield return new TestCaseData("qeBEio", "qeBEio", 6);
                yield return new TestCaseData("", "qeBEio", 0);
                yield return new TestCaseData("qeBEio", "", 0);
                yield return new TestCaseData("", "", 0);
            }
        }
    }
}
