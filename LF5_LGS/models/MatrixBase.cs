using LF5_LGS.exceptions;

namespace LF5_LGS.models;

public abstract class MatrixBase
{
    public MatrixBase(int h, int w)
    {
        data = new double[h][];
        for (var i = 0; i < h; i++) data[i] = new double[w];
    }

    public MatrixBase(double[][] data)
    {
        this.data = data;
    }

    protected double[][] data { get; set; }
    public int width { get; set; }
    public int height { get; set; }

    public double[] this[int i]
    {
        get => data[i];
        set => data[i] = value;
    }

    public double[][] getData()
    {
        return data;
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