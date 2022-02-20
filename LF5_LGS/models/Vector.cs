using LF5_LGS.models.data;

namespace LF5_LGS.models;

public class Vector : MatrixBase
{
    public Vector(double[] data) : base(new double[1][])
    {
        this.data[0] = new MatrixRow(data);
        width = 1;
        height = data.Length;
    }

    public Vector(int n) : base(1, n)
    {
        height = n;
        width = 1;
    }

    public Vector(Vector vector) : this(vector.getData()[0])
    {
    }

    public new double this[int i]
    {
        get => data[0][i];
        set => data[0][i] = value;
    }

    public int getHeight()
    {
        return data.GetLength(0);
    }

    public static Vector Copy(Vector vector)
    {
        var temp = new Vector(new double[vector.height]);
        for (var j = 0; j < vector.height; j++) temp[j] = vector[j];

        return temp;
    }
}