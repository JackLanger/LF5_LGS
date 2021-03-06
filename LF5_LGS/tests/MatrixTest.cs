using LF5_LGS.models;
using NUnit.Framework;

namespace LF5_LGS.tests;

public class MatrixTest
{
    [Test]
    public void MultiplyTest()
    {
        double[][] md =
        {
            new double[] {1, 2, 3},
            new double[] {2, 3, 1},
            new double[] {3, 2, 1}
        };
        double[][] expect =
        {
            new double[] {14, 14, 8},
            new double[] {14, 14, 8},
            new double[] {14, 14, 8}
        };

        var first = new Matrix(new[]
        {
            new double[] {1, 2, 3},
            new double[] {1, 2, 3},
            new double[] {1, 2, 3}
        });
        var second = new Matrix(md);
        var expected = new Matrix(expect);

        var res = first * second;

        Assert.AreEqual(expected.GetData(), (first * second).GetData());
    }

    [Test]
    public void SecondMultiplyTest()
    {
        double[][] md =
        {
            new double[] {1, 2, 3},
            new double[] {4, 5, 6},
            new double[] {7, 8, 9}
        };
        double[][] expect =
        {
            new double[] {12, 15, 18},
            new double[] {24, 30, 36},
            new double[] {36, 45, 54}
        };

        var first = new Matrix(new[]
        {
            new double[] {1, 1, 1},
            new double[] {2, 2, 2},
            new double[] {3, 3, 3}
        });
        var second = new Matrix(md);
        var expected = new Matrix(expect);

        var res = first * second;

        Assert.AreEqual(expected.GetData(), (first * second).GetData());
    }

    [Test]
    public void GetRankTest()
    {
        Assert.AreEqual(2, new Matrix(new[] {new double[] {1, 2}, new double[] {2, 3}}).Rank);
        Assert.AreEqual(1,
            new Matrix(new[]
            {
                new double[] {1, 2, 3, 4},
                new double[] {-3, -6, -9, -12},
                new double[] {3, 6, 9, 12},
                new double[] {2, 4, 6, 8}
            }).Rank);
    }
}