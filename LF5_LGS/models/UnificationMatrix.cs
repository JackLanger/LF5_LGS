namespace LF5_LGS.models;

public class UnificationMatrix : Matrix
{
    public UnificationMatrix(int m) : base(m, m)
    {
        for (var i = 0; i < data.Length; i++)
            data[i][i] = 1;
    }
}