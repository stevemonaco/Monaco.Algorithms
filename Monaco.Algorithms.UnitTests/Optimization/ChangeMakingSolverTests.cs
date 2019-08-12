using Monaco.Algorithms.Optimization;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monaco.Algorithms.UnitTests.Optimization
{
    [TestFixture]
    public class ChangeMakingSolverTests
    {
        [TestCaseSource(typeof(ChangeMakingSolverTestCases), "GreedySolveTestCases")]
        public void GreedySolve_AsExpected(IEnumerable<decimal> coinValues, decimal amount, IEnumerable<(decimal, int)> expected)
        {
            var actual = ChangeMakingSolver.GreedySolve(coinValues, amount);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
