using System;
using System.Linq;
using NUnit.Framework;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.Statistics;
using Monaco.Algorithms.UnitTests.AssertHelpers;

namespace Monaco.Algorithms.Extensions.UnitTests
{
    [TestFixture]
    public class MatrixExtensionTests
    {
        Matrix<double> inputMatrix;

        /// <summary>
        /// Sets up matrices for the next unit test.
        /// </summary>
        [SetUp]
        public void SetupTest()
        {
            var inputArray = new double[,] { { 26, 10, 21 }, { 25, 14, 20 }, { 34, 13, 18 }, { 29, 20, 25 }, { 23, 12, 23 } };
            inputMatrix = Matrix<double>.Build.DenseOfArray(inputArray);
        }

        [Test]
        public void CovarianceMatrix_CalculatesCorrectly()
        {
            var actualMatrix = inputMatrix.CovarianceMatrix();

            var expectedArray = new double[,] { { 18.3, 4.35, -4.95 }, { 4.35, 14.2, 5.85 }, { -4.95, 5.85, 7.3 } };
            var expectedMatrix = Matrix<double>.Build.DenseOfArray(expectedArray);

            MatrixAssert.AreAlmostEqual(expectedMatrix, actualMatrix, 2);
        }

        [Test]
        public void Standardize_ByRows_StandardizesCorrectly()
        {
            var standardMatrix = inputMatrix.Standardize(false);

            var rowMeans = standardMatrix.RowSums() / standardMatrix.ColumnCount;
            var rowVariances = standardMatrix.EnumerateRows().Select(x => x.Variance());

            Assert.Multiple(() =>
            {
                Assert.AreEqual(0d, rowMeans.Average(), 1E-6, "Means not within tolerance");
                Assert.AreEqual(1d, rowVariances.Average(), 1E-6, "Variances not within tolerance");
            });
        }

        [Test]
        public void Standardize_ByColumns_StandardizesCorrectly()
        {
            var standardMatrix = inputMatrix.Standardize(true);

            var columnMeans = standardMatrix.ColumnSums() / standardMatrix.RowCount;
            var columnVariances = standardMatrix.EnumerateColumns().Select(x => x.Variance());

            Assert.Multiple(() =>
            {
                Assert.AreEqual(0d, columnMeans.Average(), 1E-6, "Means not within tolerance");
                Assert.AreEqual(1d, columnVariances.Average(), 1E-6, "Variances not within tolerance");
            });
        }
    }
}
