using LF5_LGS.exceptions;
using LF5_LGS.models;
using NUnit.Framework;

namespace LF5_LGS.tests;

public class LgsTest
{
    [Test]
    public void TestLGS()
    {
        var resultVector = new Vector(new double[] {5, 6});
        var matrix = new Matrix(new[]
        {
            new double[] {2, 4},
            new double[] {2, 3}
        });

        var actual = Lgs.SolveLgs(matrix, resultVector);
        var expected = new Vector(new[] {4.5, -1});
        var invertedExpected = new Matrix(new[]
        {
            new[] {-1.5, 2},
            new double[] {1, -1}
        });
        var inverted = Lgs.SolveLgs(matrix);

        Assert.AreEqual(expected.getData(), actual.getData());
        Assert.AreEqual(invertedExpected.getData(), inverted.getData());
        Assert.AreEqual(new UnificationMatrix(2).getData(), (inverted * matrix).getData());
        Assert.AreEqual(new UnificationMatrix(2).getData(), (matrix * inverted).getData());
    }

    [Test]
    public void TestInvalidLGS()
    {
        var resultVector = new Vector(new double[] {5, 6});
        var matrix = new Matrix(new[]
        {
            new double[] {2, 4},
            new double[] {2, 4}
        });

        Assert.Throws<UnsolvableMatrixException>(() => Lgs.SolveLgs(matrix, resultVector));
    }
}