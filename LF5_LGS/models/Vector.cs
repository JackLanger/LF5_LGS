namespace LF5_LGS.models;

public class Vector : MatrixBase
{
    public Vector(double[] data) : base(new double[1][])
    {
        this.data[0] = data;
    }

    public Vector(int n) : base(1, n)
    {
    }

    public Vector(Vector vector) : base(vector.getData())
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
}