using MathNet.Numerics.LinearAlgebra;

namespace Monaco.Algorithms.LinearAlgebra
{
    public interface IPrincipalComponentAnalyzer
    {
        Vector<double> Eigenvalues { get; }
        Matrix<double> Eigenvectors { get; }
        Vector<double> ComponentVariances { get; }
        Vector<double> ComponentCumulativeVariances { get; }

        void Compute(in Matrix<double> matrix);
        Matrix<double> ProjectMatrix(in Matrix<double> matrix, int count);
    }
}
