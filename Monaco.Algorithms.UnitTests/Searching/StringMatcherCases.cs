using NUnit.Framework;
using System.Collections.Generic;

namespace Monaco.Algorithms.UnitTests.Searching
{
    class StringMatcherCases
    {
        public static IEnumerable<TestCaseData> FindFirstTestCases
        {
            get
            {
                yield return new TestCaseData("", "asdf", 0, -1);
                yield return new TestCaseData("asdf", "asdf", 0, 0);
                yield return new TestCaseData("the quick brown fox", "brown", 0, 10);
                yield return new TestCaseData("brown fox", "fox", 0, 6);
                yield return new TestCaseData("afoxfox", "fox", 0, 1);
                yield return new TestCaseData("afoxfox", "fox", 2, 4);
                yield return new TestCaseData("afoxfo", "fox", 2, -1);
                yield return new TestCaseData("froggerfrofrofrofrgerfroggfroggerfrofrofrofroggfroggfroggerfrogger", "frofrogger", 0, -1);
                yield return new TestCaseData("GCATCGCAGAGAGTATACAGTACG", "GCAGAGAG", 0, 5);
                yield return new TestCaseData("GCATCGCAGATAGTATACAGTACG", "GCAGAGAG", 0, -1);
            }
        }

        public static IEnumerable<TestCaseData> FindAllTestCases
        {
            get
            {
                yield return new TestCaseData("", "asdf", 0, new List<int>());
                yield return new TestCaseData("asdf", "asdf", 0, new List<int> { 0 });
                yield return new TestCaseData("asdfasdf", "asdf", 0, new List<int> { 0, 4 });
                yield return new TestCaseData("the quick brown fox", "brown", 0, new List<int> { 10 });
                yield return new TestCaseData("brown fox", "fox", 0, new List<int> { 6 });
                yield return new TestCaseData("afoxfoxafox", "fox", 0, new List<int> { 1, 4, 8 });
                yield return new TestCaseData("afoxfox", "fox", 2, new List<int> { 4 });
                yield return new TestCaseData("afoxfo", "fox", 2, new List<int>());
                yield return new TestCaseData("afoxafoxa", "fox", 0, new List<int> { 1, 5 });
            }
        }
    }
}
