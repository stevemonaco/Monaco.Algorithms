using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using Monaco.Algorithms.Extensions;

namespace Monaco.Algorithms.LinearAlgebra
{
    public enum PrincipalComponentMethod { Covariance, Svd };

    public class PrincipalComponentAnalyzer : IPrincipalComponentAnalyzer
    {
        /// <summary>
        /// Gets the PCA eigenvalues sorted by variance
        /// </summary>
        public Vector<double> Eigenvalues { get; private set; }

        /// <summary>
        /// Gets the PCA eigenvectors sorted by the eigenvalue variance
        /// </summary>
        public Matrix<double> Eigenvectors { get; private set; }

        /// <summary>
        /// Gets the sorted PCA variances
        /// </summary>
        public Vector<double> ComponentVariances { get; private set; }

        /// <summary>
        /// Gets the PCA cumulative variances
        /// </summary>
        public Vector<double> ComponentCumulativeVariances { get; private set; }

        /// <summary>
        /// Gets or sets the method by which the PCA is computed
        /// </summary>
        public PrincipalComponentMethod Method { get; set; }

        public PrincipalComponentAnalyzer(PrincipalComponentMethod method = PrincipalComponentMethod.Svd)
        {
            Method = method;
        }

        /// <summary>
        /// Computes the principle component analysis of the given matrix
        /// </summary>
        public void Compute(in Matrix<double> matrix)
        {
            IEnumerable<Tuple<double, Vector<double>>> eigenpairs;

            if (Method == PrincipalComponentMethod.Covariance)
                eigenpairs = ComputeByCovariance(matrix);
            else
                eigenpairs = ComputeBySVD(matrix);

            eigenpairs = eigenpairs.OrderByDescending(x => x.Item1);

            Eigenvalues = Vector<double>.Build.DenseOfEnumerable(eigenpairs.Select(x => x.Item1));
            Eigenvectors = Matrix<double>.Build.DenseOfRowVectors(eigenpairs.Select(x => x.Item2));

            ComponentVariances = Eigenvalues / Eigenvalues.Sum();

            var sum = 0d;
            ComponentCumulativeVariances = Vector<double>.Build.Dense(ComponentVariances.Count);
            for (int i = 0; i < ComponentVariances.Count; i++)
            {
                sum += ComponentVariances[i];
                ComponentCumulativeVariances[i] = sum;

            }

            Console.WriteLine("Eigenvalues:\n" + Eigenvalues.ToVectorString());
            Console.WriteLine("Eigenvectors:\n" + Eigenvectors.ToMatrixString());
        }

        /// <summary>
        /// Computes the Principal Component Analysis by Eigendecomposition of the Covariance matrix
        /// </summary>
        /// <param name="matrix">Input matrix</param>
        /// <returns></returns>
        private IEnumerable<Tuple<double, Vector<double>>> ComputeByCovariance(in Matrix<double> matrix)
        {
            var cov = matrix.CovarianceMatrix();
            var res = cov.Transpose().Evd(Symmetricity.Symmetric);

            // Group the unprojected PCA eigenvalues and eigenvectors into a list of tuples and sort by eigenvalue
            var eigenpairs = res.EigenValues.Enumerate().Zip(res.EigenVectors.EnumerateColumns(), (val, vec) => new Tuple<double, Vector<double>>(val.Magnitude, vec));
            return eigenpairs;
        }

        /// <summary>
        /// Computes the Principal Component Analysis by Singular Value Decomposition
        /// </summary>
        /// <param name="matrix">Input matrix</param>
        /// <returns>A list of 2-tuples containing the eigenvalues and eigenvectors of the SVD result</returns>
        private IEnumerable<Tuple<double, Vector<double>>> ComputeBySVD(in Matrix<double> matrix)
        {
            var res = matrix.Transpose().Svd();

            // After SVD, the eigenvalues are calculated by S^2 / (n-1)
            // Each row in U contains an associated eigenvector
            var eigenvalues = res.S.PointwiseMultiply(res.S) / (matrix.RowCount - 1);

            // Group the unprojected PCA eigenvalues and eigenvectors into a list of tuples and sort by eigenvalue
            var eigenpairs = eigenvalues.Enumerate().Zip(res.U.EnumerateRows(), (val, vec) => new Tuple<double, Vector<double>>(val, vec));
            return eigenpairs;
        }

        /// <summary>
        /// Projects a matrix into a new feature space according to previously computed principal components
        /// </summary>
        /// <param name="matrix">Matrix to be projected</param>
        /// <param name="count">The number of principal components to use for projection</param>
        /// <returns></returns>
        public Matrix<double> ProjectMatrix(in Matrix<double> matrix, int count)
        {
            if (matrix == null)
                throw new ArgumentNullException($"{nameof(matrix)} is null");

            if (count > Eigenvalues.Count || count < 1)
            {
                throw new ArgumentOutOfRangeException($"{nameof(ProjectMatrix)} {nameof(count)} ({count})" + 
                    $" is outside of the valid range (0, {Eigenvalues.Count})");
            }

            var projectionMatrix = Eigenvectors.SubMatrix(0, Eigenvectors.RowCount, 0, count);

            Console.WriteLine("projectionMatrix:\n" + projectionMatrix.ToMatrixString());
            return matrix.Multiply(projectionMatrix);
        }
    }
}
