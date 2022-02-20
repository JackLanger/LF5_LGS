using LF5_LGS.exceptions;
using LF5_LGS.models.data;

namespace LF5_LGS.models;

public abstract class MatrixBase
{
    public MatrixBase(int h, int w)
    {
        data = new MatrixRow[h];
        for (var i = 0; i < h; i++) data[i] = new MatrixRow(w);
    }

    public MatrixBase(double[][] data)
    {
        this.data = new MatrixRow[data.Length];
        for (var i = 0; i < data.Length; i++) this.data[i] = new MatrixRow(data[i]);
    }

    protected MatrixRow[] data { get; set; }

    /// <summary>
    ///     The Width of the matrix.
    /// </summary>
    public int width { get; set; }

    /// <summary>
    ///     The height of the matrix.
    /// </summary>
    public int height { get; set; }

    /// <summary>
    ///     Square bracket accessor for the data. Provides functionality of a array accessor [i].
    /// </summary>
    /// <param name="i">the index</param>
    public MatrixRow this[int i]
    {
        get => data[i];
        set => data[i] = value;
    }

    /// <summary>
    ///     Returns teh Arrays data.
    /// </summary>
    /// <returns>array data</returns>
    public double[][] getData()
    {
        var temp = new double[data.Length][];

        for (var i = 0; i < data.Length; i++) temp[i] = data[i].getData();

        return temp;
    }

    public static Matrix operator *(MatrixBase first, MatrixBase second)
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

    public void Pivot(int first, int second)
    {
        (this[first], this[second]) = (this[second], this[first]);
    }

    public static double[] Multiply(double alpha, double[] val)
    {
        var temp = new double[val.Length];

        for (var i = 0; i < val.Length; i++) temp[i] = alpha * val[i];

        return temp;
    }

    public void Add(int index, double[] values)
    {
        for (var i = 0; i < this[index].Length; i++) this[index][i] += values[i];
    }
}