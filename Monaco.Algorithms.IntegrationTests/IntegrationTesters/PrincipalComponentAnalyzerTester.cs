using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using AlgorithmIntegrationTests.Models;
using Monaco.Algorithms.Extensions;
using MathNet.Numerics.LinearAlgebra;
using AlgorithmIntegrationTests.DataSetLoaders;
using Monaco.Algorithms.LinearAlgebra;

namespace AlgorithmIntegrationTests.IntegrationTesters
{
    [TestFixture]
    class PrincipalComponentAnalyzerTester : IIntegrationTester
    {
        Matrix<double> IrisMatrix;

        [OneTimeSetUp]
        public void Setup()
        {
            var irisLoader = new IrisLoader();
            var irisData = irisLoader.Load();

            IrisMatrix = Matrix<double>.Build.Dense(irisData.Count, 4);

            int row = 0;
            foreach (var model in irisData)
            {
                IrisMatrix[row, 0] = model.SepalLength;
                IrisMatrix[row, 1] = model.SepalWidth;
                IrisMatrix[row, 2] = model.PetalLength;
                IrisMatrix[row, 3] = model.PetalWidth;
                row++;
            }
        }

        public void RunTestByName(string name)
        {
            throw new NotImplementedException();
        }

        public void RunTests()
        {
            var stdMatrix = IrisMatrix.Standardize();

            var pca = new PrincipalComponentAnalyzer();

            pca.Compute(stdMatrix);
            var projectedMatrix = pca.ProjectMatrix(stdMatrix, 2);

            File.WriteAllText("G:\\testmat.txt", projectedMatrix.ToMatrixString(projectedMatrix.RowCount, projectedMatrix.ColumnCount));
            Console.WriteLine(projectedMatrix.ToMatrixString());
        }
        
        /*[Test]
        public void TestPCABySVD()
        {
            var stdMatrix = IrisMatrix.Standardize();
            var pca = new PrincipalComponentAnalyzer(PrincipalComponentMethod.Svd);

            pca.Compute(stdMatrix);
            var projectedMatrix = pca.ProjectMatrix(stdMatrix, 2);

            Assert.AreEqual(true, false);
        }

        [Test]
        public void TestPCAByCovariance()
        {
            var stdMatrix = IrisMatrix.Standardize();
            var pca = new PrincipalComponentAnalyzer(PrincipalComponentMethod.Covariance);

            pca.Compute(stdMatrix);
            var projectedMatrix = pca.ProjectMatrix(stdMatrix, 2);

            Assert.AreEqual(true, false);
        }*/
    }
}
