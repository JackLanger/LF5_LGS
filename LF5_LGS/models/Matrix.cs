using LF5_LGS.exceptions;

namespace LF5_LGS.models;

public class Matrix : MatrixBase
{
    public Matrix(double[][] data) : base(data)
    {
        height = data.Length;
        width = data.GetLength(0);
    }

    public Matrix(int m, int n) : base(m, n)
    {
        data = new double[m][];
        for (var i = 0; i < m; i++) data[i] = new double[n];
        width = n;
        height = m;
    }


    public static Matrix operator *(Matrix first, MatrixBase second)
    {
        if (first.width != second.height)
            throw new InvalidMatrixOperationException(
                "invalid operation, matrices cannot be multiplied!");

        var result = new Matrix(first.height, second.width);

        for (var i = 0; i < first.height; i++)
        for (var j = 0; j < first.width; j++)
        for (var k = 0; k < first.width; k++)
            result[i][j] += first[i][k] * second[k][j];

        return result;
    }

    public static Matrix operator *(double alpha, Matrix matrix)
    {
        Matrix temp = new(matrix.height, matrix.width);

        for (var i = 0; i < matrix.height; i++)
        for (var j = 0; j < matrix.width; j++)
            temp[i][j] = matrix[i][j] * alpha;

        return temp;
    }

    public static Matrix Copy(MatrixBase matrix)
    {
        var temp = new double[matrix.height][];
        for (var i = 0; i < matrix.height; i++)
        {
            temp[i] = new double[matrix.width];
            for (var j = 0; j < matrix.width; j++) temp[i][j] = matrix[i][j];
        }

        return new Matrix(temp);
    }
}