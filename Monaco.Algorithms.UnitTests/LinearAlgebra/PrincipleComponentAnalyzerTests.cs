using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using Monaco.Algorithms.Extensions;
using Monaco.Algorithms.LinearAlgebra;
using Monaco.Algorithms.UnitTests.AssertHelpers;
using NUnit.Framework;

namespace Monaco.Algorithms.UnitTests.LinearAlgebra
{
    [TestFixture]
    class PrincipleComponentAnalyzerTests
    {
        PrincipalComponentAnalyzer pca;

        /// <summary>
        /// A matrix of shape [3, 11]
        /// </summary>
        Matrix<double> inputMatrix;

        [SetUp]
        public void Setup()
        {
            var inputArray = new double[,] { { 7, 4, 6, 8, 8, 7, 5, 9, 7, 8 },
                { 4, 1, 3, 6, 5, 2, 3, 5, 4, 2 },
                { 3, 8, 5, 1, 7, 9, 3, 8, 5, 2 } };
            inputMatrix = Matrix<double>.Build.DenseOfArray(inputArray).Transpose();

            pca = new PrincipalComponentAnalyzer(PrincipalComponentMethod.Covariance);
        }

        // Disabled due to inconsistent ordering of eigenvalues
        /*[Test]
        public void ProjectMatrix_CalculatesCorrectly()
        {
            var expectedArray = new double[,] { { 0.41, -2.11, -0.46, 1.62, 0.70, -0.86, -0.60, 0.94, 0.22, 0.15 },
                { -0.69, 0.07, -0.32, -1.00, 1.09, 1.32, -1.31, 1.72, 0.03, -0.91 },
                { 0.06, 0.63, 0.30, 0.70, 0.65, -0.85, 0.86, -0.04, 0.34, -2.65 } };
            var expectedMatrix = Matrix<double>.Build.DenseOfArray(expectedArray).Transpose();

            var stdMatrix = inputMatrix.Standardize();
            pca.Compute(stdMatrix);
            var projectedMatrix = pca.ProjectMatrix(stdMatrix, 3);

            MatrixAssert.AreAlmostEqual(expectedMatrix, projectedMatrix, 2);
        }*/

        [TestCase(4)]
        [TestCase(0)]
        [TestCase(-5)]
        public void ProjectMatrix_CountOutOfRange_ThrowsException(int count)
        {
            pca.Compute(inputMatrix);

            Assert.Throws<ArgumentOutOfRangeException>(() => { pca.ProjectMatrix(inputMatrix, count); });
        }
    }
}
