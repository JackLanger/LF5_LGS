namespace LF5_LGS.exceptions;

public class UnsolvableMatrixException : Exception
{
    public UnsolvableMatrixException() : base("this matrix cannot be solved with a LGS")
    {
    }
}