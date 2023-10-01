using _2_Triangle_Type_Detector.Analysis;

namespace _2_Triangle_Type_Detector.Tests.NUnit;

public class TriangleTypeDetectorTests
{
    [TestCase(7, 7, 7, TriangleType.Equilateral)]
    [TestCase(3, 4, 5, TriangleType.RightAngled)]
    [TestCase(50, 50, 1, TriangleType.Isosceles)]
    [TestCase(2, 2, 55, TriangleType.Invalid)]
    public void TestEquivalencePartitioning(double sideA, double sideB, double sideC, TriangleType expected)
    {
        Assert.That(TriangleTypeDetector.DetermineType(new Triangle(sideA, sideB, sideC)), Is.EqualTo(expected));
    }

    [TestCase(double.MaxValue, double.MaxValue, double.MaxValue, TriangleType.Equilateral)]
    [TestCase(double.MaxValue * 2, double.MaxValue * 2, double.MaxValue * 2, TriangleType.Invalid)]
    [TestCase(double.MinValue, double.MinValue, double.MinValue, TriangleType.Invalid)]
    [TestCase(0, 0, 0, TriangleType.Invalid)]
    public void TestBoundaryValues(double sideA, double sideB, double sideC, TriangleType expected)
    {
        Assert.That(TriangleTypeDetector.DetermineType(new Triangle(sideA, sideB, sideC)), Is.EqualTo(expected));
    }
}