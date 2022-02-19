using LF5_LGS.exceptions;
using LF5_LGS.models;

namespace LF5_LGS;

public class LGS
{
    public static MatrixBase SolveLgs(Matrix matrix, Vector? result = null)
    {
        MatrixBase res;
        if (result is not null)
            res = new Vector(result.matrixData[0]);
        else
            res = new UnificationMatrix(matrix.height);

        var temp = CopyMatrixArray(matrix);

        IterateDown(result, res, temp);
        IterateUp(result, res, temp);
        Normalize(temp, res);

        return res;
    }

    private static double[][] CopyMatrixArray(Matrix matrix)
    {
        var temp = new double[matrix.height][];
        for (var i = 0; i < matrix.height; i++)
        {
            temp[i] = new double[matrix.width];
            for (var j = 0; j < matrix.width; j++) temp[i][j] = matrix.matrixData[i][j];
        }

        return temp;
    }

    private static void Normalize(double[][] temp, MatrixBase res)
    {
        for (var i = 0; i < temp.Length; i++)
        {
            var alpha = 1 / temp[i][i];
            if (res is not Vector)
                for (var j = 0; j < res.matrixData.Length; j++)
                    res.matrixData[i][j] *= alpha;
            else
                res.matrixData[0][i] *= alpha;

            temp[i][i] /= temp[i][i];
        }
    }

    private static void IterateDown(Vector? result, MatrixBase res, double[][] temp)
    {
        for (var i = 0; i < temp.Length - 1; i++)
        {
            if (temp[i + 1][i] == 0)
            {
                pivot(ref temp[i], ref temp[i + 1]);
                if (temp[i + 1][i] == 0)
                    throw new UnsolvableMatrixException();
            }


            var topRow = temp[i];
            for (var h = i; h < temp.Length - 1; h++)
            {
                var currentRow = temp[h + 1];
                var rowAlpha = -currentRow[i] / topRow[i];

                // there was an solving vector provided, therefore it needs to be updated. 
                if (result is not null && h == i)
                    res.matrixData[0][i + 1] += rowAlpha * res.matrixData[0][i];

                for (var j = i; j < temp.Length; j++)
                {
                    // no solving vector was provided we use the unification vector
                    if (res is UnificationMatrix)
                        res.matrixData[h + 1][j] +=
                            rowAlpha * res.matrixData[i][j];

                    temp[h + 1][j] = rowAlpha * topRow[j] + currentRow[j];
                }
            }
        }
    }

    private static void IterateUp(Vector? result, MatrixBase res, double[][] temp)
    {
        for (var i = temp.Length - 1; i >= 0; i--)
        {
            var topRow = temp[i];
            for (var h = i; h >= 1; h--)
            {
                var currentRow = temp[h - 1];
                var rowAlpha = -currentRow[i] / topRow[i];

                // there was an solving vector provided, therefore it needs to be updated. 
                if (result is not null && h == i)
                    res.matrixData[0][i - 1] += rowAlpha * res.matrixData[0][i];

                for (var j = i; j >= 1; j--)
                {
                    // no solving vector was provided we use the unification vector
                    if (res is UnificationMatrix)
                        res.matrixData[h - 1][j] +=
                            rowAlpha * res.matrixData[i][j];

                    temp[h - 1][j] = rowAlpha * topRow[j] + currentRow[j];
                }
            }
        }
    }

    private static void pivot(ref double[] firstRow, ref double[] secondRow)
    {
        var temp = new double[secondRow.Length];
        secondRow.CopyTo(temp, 0);
        secondRow = firstRow;
        secondRow = temp;
    }
}