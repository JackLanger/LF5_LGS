namespace LF5_LGS.exceptions;

public class InvalidMatrixOperationException : Exception
{
    public InvalidMatrixOperationException() : this("this operation is not valid.")
    {
    }

    public InvalidMatrixOperationException(string msg) : base(msg)
    {
    }
}