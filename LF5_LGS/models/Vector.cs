using LF5_LGS.models.data;

namespace LF5_LGS.models;

public class Vector : MatrixBase
{
    public Vector(double[] data) : base(new double[1][])
    {
        Data[0] = new MatrixRow(data);
        Width = 1;
        Height = data.Length;
    }

    public Vector(int n) : base(1, n)
    {
        Height = n;
        Width = 1;
    }

    public Vector(Vector vector) : this(vector.GetData()[0])
    {
    }

    private new double this[int i]
    {
        get => Data[0][i];
        set => Data[0][i] = value;
    }

    public int GetHeight()
    {
        return Data.GetLength(0);
    }

    public static Vector Copy(Vector vector)
    {
        var temp = new Vector(new double[vector.Height]);
        for (var j = 0; j < vector.Height; j++) temp[j] = vector[j];

        return temp;
    }
}