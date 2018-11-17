using System;
using System.Collections.Generic;
using NUnit.Framework;
using MathNet.Numerics.LinearAlgebra;

namespace Monaco.Algorithms.UnitTests.AssertHelpers
{
    static class MatrixAssert
    {
        /// <summary>
        /// Performs element-wise comparison between two matrices and asserts they are equal to decimalPlaces precision
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="actual"></param>
        public static void AreAlmostEqual(Matrix<double> expected, Matrix<double> actual, int decimalPlaces)
        {
            if (expected.ColumnCount != actual.ColumnCount || expected.RowCount != actual.RowCount)
                Assert.Fail("Matrix dimensions mismatch. Expected: {0}; Actual: {1}", expected.ToTypeString(), actual.ToTypeString());

            for (var i = 0; i < expected.RowCount; i++)
            {
                for (var j = 0; j < expected.ColumnCount; j++)
                {
                    if (!AlmostEqual(expected.At(i, j), actual.At(i, j), decimalPlaces))
                        Assert.Fail($"Not equal within {decimalPlaces} places.\n" +
                            $"Expected value: {expected.At(i, j)}; Actual value: {actual.At(i, j)}\n");
                }
            }
        }

        /// <summary>
        /// Compares two values and evaluates whether they are equal to within decimalPlaces precision
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="decimalPlaces">Precision to the nth decimal place</param>
        private static bool AlmostEqual(double a, double b, int decimalPlaces)
        {
            if (double.IsNaN(a) || double.IsNaN(b))
                return false;

            if (double.IsInfinity(a) || double.IsInfinity(b))
                return a == b;

            double diff = a - b;
            double precision = Math.Pow(10, -decimalPlaces) / 2d; // Division by two accomodates for diff rounding

            return Math.Abs(diff) < precision;
        }
    }
}
