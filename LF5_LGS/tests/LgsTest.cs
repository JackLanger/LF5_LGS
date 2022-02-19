using LF5_LGS.models;
using NUnit.Framework;

namespace LF5_LGS.tests;

public class LgsTest
{
    [Test]
    public void TestLGS()
    {
        var resultVector = new Vector(new double[] {1, 2, 3});
        var matrix = new Matrix(new[]
        {
            new double[] {1, 2, 3},
            new double[] {3, 2, 1},
            new double[] {2, 3, 1}
        });

        var res = LGS.SolveLgs(matrix, resultVector);
        Assert.AreEqual(
            new Vector(new[] {-3.833333333333333, 2.4166666666666665, -1.0833333333333333})
                .getData(),
            res.getData());
        var inverted = LGS.SolveLgs(matrix);
        var uniRes = inverted * matrix;
        Assert.AreEqual(new UnificationMatrix(matrix.height).getData(),
            uniRes.getData());
    }
}