using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Statistics;

namespace Monaco.Algorithms.Extensions
{
    public static class MatrixExtensions
    {
        /// <summary>
        /// Standardizes each row or column of a matrix to a mean of 0 and variance of 1 along the specified axis
        /// </summary>
        /// <param name="matrix">An input matrix which is modified</param>
        /// <param name="byColumn">True if to standardize each column, false if to standardize each row of the matrix</param>
        /// <param name="targetMean">Standardized mean of each row or column</param>
        /// <param name="targetVariance">Standardized variance of each row or column</param>
        public static void StandardizeThis(this Matrix<double> matrix, bool byColumn=true, double targetMean = 0.0, double targetVariance = 1.0)
        {
            if (byColumn)
            {
                foreach (var (index, col) in matrix.EnumerateColumnsIndexed())
                {
                    var mean = col.Mean();
                    var stdev = Math.Sqrt(col.Variance() / targetVariance);
                    matrix.SetColumn(index, col.Subtract(mean).Divide(stdev).Subtract(targetMean));
                }
            }
            else
            {
                foreach (var (index, row) in matrix.EnumerateRowsIndexed())
                {
                    var mean = row.Mean();
                    var stdev = Math.Sqrt(row.Variance() / targetVariance);
                    matrix.SetRow(index, row.Subtract(mean).Divide(stdev).Subtract(targetMean));
                }
            }
        }

        /// <summary>
        /// Standardizes each row or column of a matrix to a mean of 0 and variance of 1 along the specified axis
        /// </summary>
        /// <param name="matrix">Input matrix</param>
        /// <param name="byColumn">True if to standardize each column, false if to standardize each row of the matrix</param>
        /// <param name="targetMean">Standardized mean of each row or column</param>
        /// <param name="targetVariance">Standardized variance of each row or column</param>
        /// <returns>A new standardized matrix</returns>
        public static Matrix<double> Standardize(this Matrix<double> matrix, bool byColumn=true, double targetMean = 0.0, double targetVariance = 1.0)
        {
            var retMat = matrix.Clone();
            retMat.StandardizeThis(byColumn, targetMean, targetVariance);
            return retMat;
        }

        /// <summary>
        /// Creates a new covariance matrix
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns>The covariance matrix</returns>
        /// <see cref="https://stackoverflow.com/questions/32256998/find-covariance-of-math-net-matrix"/>
        public static Matrix<double> CovarianceMatrix(this Matrix<double> matrix)
        {
            var columnAverages = matrix.ColumnSums() / matrix.RowCount;
            var centeredColumns = matrix.EnumerateColumns().Zip(columnAverages, (col, avg) => col - avg);
            var centeredMat = Matrix<double>.Build.DenseOfColumnVectors(centeredColumns);
            var normalizationFactor = Math.Max(matrix.RowCount - 1, 1);

            return centeredMat.TransposeThisAndMultiply(centeredMat) / normalizationFactor;
        }
    }
}
