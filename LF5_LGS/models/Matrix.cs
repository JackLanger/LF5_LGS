using LF5_LGS.exceptions;
using LF5_LGS.models.data;

namespace LF5_LGS.models;

/// <summary>
///     A Matrix.
/// </summary>
public class Matrix : MatrixBase
{
    public Matrix(double[][] data) : base(data)
    {
        Height = data.Length;
        Width = data.GetLength(0);
    }

    public Matrix(int m, int n) : base(m, n)
    {
        Data = new MatrixRow[m];
        for (var i = 0; i < m; i++) Data[i] = new MatrixRow(n);
        Width = n;
        Height = m;
    }

    /// <summary>
    ///     Multiplies two matrices with each other and returns a new Matrix with that is the size MxN
    ///     where m is the width of the first and N the height of the second matrix.
    /// </summary>
    /// <param name="first"> Matrix</param>
    /// <param name="second"> Matrix</param>
    /// <returns>new Matrix with size MxN</returns>
    /// <exception cref="InvalidMatrixOperationException"></exception>
    public static Matrix operator *(Matrix first, MatrixBase second)
    {
        if (first.Width != second.Height)
            throw new InvalidMatrixOperationException(
                "invalid operation, matrices cannot be multiplied!");

        var result = new Matrix(first.Height, second.Width);

        for (var i = 0; i < first.Height; i++)
        for (var j = 0; j < first.Width; j++)
        for (var k = 0; k < first.Width; k++)
            result[i][j] += first[i][k] * second[k][j];

        return result;
    }

    /// <summary>
    ///     Multiplies a Matrix with a given alpha and returns the result.
    /// </summary>
    /// <param name="alpha"> factor by which the values are multiplied</param>
    /// <param name="matrix"> the matrix</param>
    /// <returns> new Matrix that is alhpa *  the old matrix</returns>
    public static Matrix operator *(double alpha, Matrix matrix)
    {
        Matrix temp = new(matrix.Height, matrix.Width);

        for (var i = 0; i < matrix.Height; i++)
        for (var j = 0; j < matrix.Width; j++)
            temp[i][j] = matrix[i][j] * alpha;

        return temp;
    }

    /// <summary>
    ///     Returns a copy of the matrix as a new object. This new Object is no reference of the old one
    ///     but a completely new and independent object.
    /// </summary>
    /// <param name="matrix">matrix to copy</param>
    /// <returns> copy of the matrix</returns>
    public static Matrix Copy(MatrixBase matrix)
    {
        var temp = new double[matrix.Height][];
        for (var i = 0; i < matrix.Height; i++)
        {
            temp[i] = new double[matrix.Width];
            for (var j = 0; j < matrix.Width; j++) temp[i][j] = matrix[i][j];
        }

        return new Matrix(temp);
    }
}