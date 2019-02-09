using System.Collections.Generic;
using NUnit.Framework;

namespace Monaco.Algorithms.UnitTests.Sequences
{
    class LongestIncreasingSubsequenceTestCases
    {
        public static IEnumerable<TestCaseData> LisLengthIntCases
        {
            get
            {
                yield return new TestCaseData(new int[] { 10, 51, 75, 42 }, 3);
                yield return new TestCaseData(new int[] { 75, 10, 42, 51 }, 3);
                yield return new TestCaseData(new int[] { 75, 3, 8, 51, 15, 21 }, 4);
                yield return new TestCaseData(new int[] { 75 }, 1);
                yield return new TestCaseData(new int[] { }, 0);
            }
        }

        public static IEnumerable<TestCaseData> LisListIntCases
        {
            get
            {
                yield return new TestCaseData(new int[] { 10, 51, 75, 42 },
                    new List<List<int>>() { new List<int>() { 10, 51, 75 } });

                yield return new TestCaseData(new int[] { 75, 10, 42, 51 },
                    new List<List<int>>() { new List<int>() { 10, 42, 51 } });

                yield return new TestCaseData(new int[] { 75, 3, 8, 51, 15, 21 },
                    new List<List<int>>() { new List<int>() { 3, 8, 15, 21 } });

                yield return new TestCaseData(new int[] { 75 },
                    new List<List<int>>() { new List<int>() { 75 } });

                yield return new TestCaseData(new int[] { 75, 50 },
                    new List<List<int>>() { new List<int>() { 75 }, new List<int>() { 50 } });

                yield return new TestCaseData(new int[] { 40, 50, 60, 10, 20, 30 },
                    new List<List<int>>() { new List<int>() { 40, 50, 60 }, new List<int>() { 10, 20, 30 } });

                yield return new TestCaseData(new int[] { },
                    new List<List<int>>());
            }
        }
    }
}
