namespace LF5_LGS.models.data;

public class MatrixRow
{
    protected double[] data;

    public MatrixRow(int height)
    {
        data = new double[height];
    }

    public MatrixRow(double[] data)
    {
        this.data = data;
    }

    public bool IsNullRow
    {
        get
        {
            for (var i = 0; i < Length; i++)
                if (data[i] != 0)
                    return false;

            return true;
        }
    }

    public double this[int i]
    {
        get => data[i];
        set => data[i] = value;
    }

    public int Length => data.Length;


    public static MatrixRow operator +(MatrixRow first, MatrixRow second)
    {
        var temp = new MatrixRow(first.Length);

        for (var i = 0; i < first.Length; i++) temp[i] = second[i] + first[i];

        return temp;
    }

    public static MatrixRow operator *(MatrixRow val, double alpha)
    {
        return alpha * val;
    }

    public static MatrixRow operator *(double alpha, MatrixRow val)
    {
        var temp = new MatrixRow(val.Length);

        for (var i = 0; i < val.Length; i++) temp[i] = val[i] * alpha;

        return temp;
    }

    public double[] getData()
    {
        return data;
    }
}