namespace LF5_LGS.models.data;

public class MatrixRow
{
    private readonly double[] _data;

    public MatrixRow(int height)
    {
        _data = new double[height];
    }

    public MatrixRow(double[] data)
    {
        _data = data;
    }

    public bool IsNullRow
    {
        get
        {
            for (var i = 0; i < Length; i++)
                if (_data[i] != 0)
                    return false;

            return true;
        }
    }

    public double this[int i]
    {
        get => _data[i];
        set => _data[i] = value;
    }

    private int Length => _data.Length;


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

    public double[] GetData()
    {
        return _data;
    }
}