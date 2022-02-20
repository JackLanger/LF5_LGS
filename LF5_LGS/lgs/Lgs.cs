using LF5_LGS.exceptions;
using LF5_LGS.models;

namespace LF5_LGS;

/// <summary>
///     Class for solving Matrizes.
/// </summary>
public static class Lgs
{
    /// <summary>
    ///     Solves a matrix with its respective solving vector, if the solving vector is not provided this
    ///     function returns the inverse of the matrix
    /// </summary>
    /// <param name="matrix"> the matrix to solve</param>
    /// <param name="result"> the result vector</param>
    /// <returns> a new vector containing the result or the inverse matrix if no vector was provided</returns>
    public static MatrixBase SolveLgs(Matrix matrix, Vector? result = null)
    {
        MatrixBase res;
        if (result is not null)
            res = Vector.Copy(result);
        else
            res = new UnificationMatrix(matrix.height);

        var temp = Matrix.Copy(matrix);

        IterateDown(result, res, temp);
        IterateUp(result, res, temp);
        Normalize(temp, res);

        return res;
    }

    private static void Normalize(Matrix temp, MatrixBase res)
    {
        for (var i = 0; i < temp.height; i++)
        {
            if (temp[i].IsNullRow)
                throw new UnsolvableMatrixException();
            var alpha = 1 / temp[i][i];
            temp[i][i] *= alpha;
            if (res is not Vector)
                res[i] *= alpha;
            // res[i] = MatrixBase.Multiply(alpha, res[i]);
            else
                res[0][i] *= alpha;
        }
    }

    private static void IterateDown(Vector? result, MatrixBase res, Matrix temp)
    {
        for (var i = 0; i < temp.height - 1; i++)
        {
            if (temp[i + 1][i] == 0)
            {
                temp.Pivot(i, i + 1);
                res.Pivot(i, i + 1);
                if (temp[i + 1][i] == 0)
                    throw new UnsolvableMatrixException();
            }


            var topRow = temp[i];
            for (var h = i; h < temp.height - 1; h++)
            {
                var currentRow = temp[h + 1];
                var rowAlpha = -currentRow[i] / topRow[i];

                // there was an solving vector provided, therefore it needs to be updated. 
                if (result is not null && h == i)
                    res[0][i + 1] += rowAlpha * res[0][i];

                for (var j = i; j < temp.height; j++)
                {
                    // no solving vector was provided we use the unification vector
                    if (res is UnificationMatrix)
                        res[h + 1][j] +=
                            rowAlpha * res[i][j];

                    temp[h + 1][j] = rowAlpha * topRow[j] + currentRow[j];
                }
            }
        }
    }

    private static void IterateUp(Vector? result, MatrixBase res, Matrix temp)
    {
        for (var i = temp.height - 1; i >= 0; i--)
        {
            var topRow = temp[i];
            for (var h = i; h >= 1; h--)
            {
                var currentRow = temp[h - 1];
                var rowAlpha = -currentRow[i] / topRow[i];

                // there was an solving vector provided, therefore it needs to be updated. 
                if (result is not null && h == i)
                    res[0][i - 1] += rowAlpha * res[0][i];
                else if (h == i)
                    res[h - 1] += res[h] * rowAlpha;
                // res.Add(h - 1, MatrixBase.Multiply(rowAlpha, res[h]));

                for (var j = i; j >= 1; j--)
                    // no solving vector was provided we use the unification vector
                    temp[h - 1][j] = rowAlpha * topRow[j] + currentRow[j];
            }
        }
    }
}