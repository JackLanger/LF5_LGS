using LF5_LGS.exceptions;

namespace LF5_LGS.models;

public abstract class MatrixBase
{
    public double[][] matrixData { get; set; }
    public int width { get; set; }
    public int height { get; set; }

    public static MatrixBase operator *(MatrixBase first, MatrixBase second)
    {
        if (first.width != second.height)
            throw new InvalidMatrixOperationException(
                "invalid operation, matrices cannot be multiplied!");

        var result = new Matrix(first.height, second.width);

        for (var i = 0; i < first.height; i++)
        for (var j = 0; j < first.width; j++)
        for (var k = 0; k < first.width; k++)
            result.matrixData[i][j] += first.matrixData[i][k] * second.matrixData[k][j];

        return result;
    }
}