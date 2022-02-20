using LF5_LGS.exceptions;
using LF5_LGS.models.data;

namespace LF5_LGS.models;

public abstract class MatrixBase
{
    protected MatrixBase(int h, int w)
    {
        Data = new MatrixRow[h];
        for (var i = 0; i < h; i++) Data[i] = new MatrixRow(w);
    }

    protected MatrixBase(double[][] data)
    {
        Data = new MatrixRow[data.Length];
        for (var i = 0; i < data.Length; i++) Data[i] = new MatrixRow(data[i]);
    }

    protected MatrixRow[] Data { get; init; }

    /// <summary>
    ///     The Width of the matrix.
    /// </summary>
    public int Width { get; protected init; }

    /// <summary>
    ///     The height of the matrix.
    /// </summary>
    public int Height { get; protected init; }

    /// <summary>
    ///     Square bracket accessor for the data. Provides functionality of a array accessor [i].
    /// </summary>
    /// <param name="i">the index</param>
    public MatrixRow this[int i]
    {
        get => Data[i];
        set => Data[i] = value;
    }

    /// <summary>
    ///     Returns teh Arrays data.
    /// </summary>
    /// <returns>array data</returns>
    public double[][] GetData()
    {
        var temp = new double[Data.Length][];

        for (var i = 0; i < Data.Length; i++) temp[i] = Data[i].getData();

        return temp;
    }

    public static Matrix operator *(MatrixBase first, MatrixBase second)
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
    ///     Swaps two rows.
    /// </summary>
    /// <param name="first">double[] first row</param>
    /// <param name="second">double[] second row</param>
    public void Swap(int first, int second)
    {
        (this[first], this[second]) = (this[second], this[first]);
    }
}