namespace LF5_LGS.models;

public class Matrix : MatrixBase
{
    public Matrix(double[][] data)
    {
        matrixData = data;
        height = data.Length;
        width = data.GetLength(0);
    }

    public Matrix(int m, int n)
    {
        matrixData = new double[m][];
        for (var i = 0; i < m; i++) matrixData[i] = new double[n];
        width = n;
        height = m;
    }

    // public static MatrixBase operator *(Matrix first, MatrixBase second)
    // {
    //     if (first.width != second.height)
    //         throw new InvalidMatrixOperationException(
    //             "invalid operation, matrices cannot be multiplied!");
    //
    //     var result = new Matrix(first.height, second.width);
    //
    //     for (var i = 0; i < first.height; i++)
    //     for (var j = 0; j < first.width; j++)
    //     for (var k = 0; k < first.width; k++)
    //         result.matrixData[i][j] += first.matrixData[i][k] * second.matrixData[k][j];
    //
    //     return result;
    // }
}