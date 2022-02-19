namespace LF5_LGS.models;

public class Vector : MatrixBase
{
    public Vector(double[] data)
    {
        matrixData = new double[1][];
        matrixData[0] = data;
    }

    public Vector(int n)
    {
        matrixData = new double[1][];
        matrixData[0] = new double[n];
    }

    public int getHeight()
    {
        return matrixData.GetLength(0);
    }
}