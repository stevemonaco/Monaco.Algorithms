using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Monaco.Algorithms.UnitTests.Searching
{
    class SearchTestCases
    {
        public static IEnumerable<TestCaseData> FindFirstItemIntTestCases
        {
            get
            {
                yield return new TestCaseData(new List<int> { }, 0, -1);
                yield return new TestCaseData(new List<int> { 5 }, 5, 0);
                yield return new TestCaseData(new List<int> { 5, 8, 6, 5, 8 }, 8, 1);
                yield return new TestCaseData(new List<int> { 5, 2, 9, 2, 0 }, 0, 4);
                yield return new TestCaseData(new List<int> { 5, 2, 9, 2, 0 }, 4, -1);
            }
        }

        public static IEnumerable<TestCaseData> FindFirstSequenceIntTestCases
        {
            get
            {
                yield return new TestCaseData(new List<int> { }, new List<int>(), -1);
                yield return new TestCaseData(new List<int> { 5 }, new List<int> { 5 }, 0);
                yield return new TestCaseData(new List<int> { 5, 8, 6, 5, 8 }, new List<int> { 8 }, 1);
                yield return new TestCaseData(new List<int> { 5, 2, 9, 2, 0 }, new List<int> { 0 }, 4);
                yield return new TestCaseData(new List<int> { 5, 2, 9, 2, 0 }, new List<int> { 4 }, -1);
                yield return new TestCaseData(new List<int> { 5, 2, 9, 2, 0 }, new List<int> { 5, 2 }, 0);
                yield return new TestCaseData(new List<int> { 5, 2, 9, 2, 0 }, new List<int> { 9, 2, 0 }, 2);
                yield return new TestCaseData(new List<int> { 5, 2, 9, 2, 0 }, new List<int> { 5, 2, 9, 2, 0 }, 0);
            }
        }


        
    }
}
