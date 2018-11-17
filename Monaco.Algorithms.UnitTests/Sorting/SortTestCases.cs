using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Monaco.Algorithms.UnitTests.Sorting
{
    public class SortTestCases
    {
        public static IEnumerable<TestCaseData> StringSortCases
        {
            get
            {
                yield return new TestCaseData(new List<string> { "cat" });
                yield return new TestCaseData(new List<string> { "cat", "bee" });
                yield return new TestCaseData(new List<string> { "bird", "cat", "dog" });
                yield return new TestCaseData(new List<string> { "dragon", "crow", "bat"});
                yield return new TestCaseData(new List<string> { "squirrel", "elephant", "fish", "aardvark" });
                yield return new TestCaseData(new List<string> { "mouse", "bear", "slug", "ant", "zebra", "tiger", "lion", "frog", "starfish", "toad", "beetle" });
            }
        }
    }
}
