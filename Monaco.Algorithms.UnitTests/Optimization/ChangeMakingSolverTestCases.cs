using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monaco.Algorithms.UnitTests.Optimization
{
    public class ChangeMakingSolverTestCases
    {
        public static IEnumerable<TestCaseData> GreedySolveTestCases
        {
            get
            {
                yield return new TestCaseData(new decimal[] { 0.25m, 0.10m, 0.05m, 0.01m }, 1.00m,
                    new (decimal, int)[] { (0.25m, 4), (0.10m, 0), (0.05m, 0), (0.01m, 0) });

                yield return new TestCaseData(new decimal[] { 0.25m, 0.10m, 0.05m, 0.01m }, 0.41m,
                    new (decimal, int)[] { (0.25m, 1), (0.10m, 1), (0.05m, 1), (0.01m, 1) });

                yield return new TestCaseData(new decimal[] { 0.25m, 0.10m, 0.05m, 0.01m }, 0.01m,
                    new (decimal, int)[] { (0.25m, 0), (0.10m, 0), (0.05m, 0), (0.01m, 1) });
            }
        }
    }
}
