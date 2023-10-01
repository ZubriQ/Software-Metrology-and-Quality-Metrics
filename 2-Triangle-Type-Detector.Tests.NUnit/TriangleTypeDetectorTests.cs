using _2_Triangle_Type_Detector.Analysis;

namespace _2_Triangle_Type_Detector.TriangleTypeDetectorTests.NUnit;

public class TriangleTypeDetectorTests
{
    private static readonly TriangleTypeDetector _detector = new();

    [Test]
    public void TestEquivalencePartitioning()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_detector.DetermineType(new Triangle(7, 7, 7)), Is.EqualTo(TriangleType.Equilateral));
            Assert.That(_detector.DetermineType(new Triangle(3, 4, 5)), Is.EqualTo(TriangleType.RightAngled));
            Assert.That(_detector.DetermineType(new Triangle(50, 50, 1)), Is.EqualTo(TriangleType.Isosceles));
            Assert.That(_detector.DetermineType(new Triangle(2, 2, 55)), Is.EqualTo(TriangleType.Invalid));
        });
    }

    [Test]
    public void TestBoundaryValues()
    {
        Assert.Multiple(() =>
        {
            Assert.That(_detector.DetermineType(new Triangle(double.MaxValue + double.MaxValue, double.MaxValue + double.MaxValue, double.MaxValue + double.MaxValue)), Is.EqualTo(TriangleType.Invalid));
            Assert.That(_detector.DetermineType(new Triangle(double.MaxValue, double.MaxValue, double.MaxValue)), Is.EqualTo(TriangleType.Equilateral));
            Assert.That(_detector.DetermineType(new Triangle(double.MinValue, double.MinValue, double.MinValue)), Is.EqualTo(TriangleType.Invalid));
            Assert.That(_detector.DetermineType(new Triangle(0, 0, 0)), Is.EqualTo(TriangleType.Invalid));
        });
    }
}