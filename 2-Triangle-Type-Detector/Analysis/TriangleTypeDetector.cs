namespace _2_Triangle_Type_Detector.Analysis;

public static class TriangleTypeDetector
{
    private const double Tolerance = 1e-10;

    public static TriangleType? DetermineType(Triangle triangle) =>
        IsValid(triangle) ?? IsEquilateral(triangle) ?? IsRight(triangle) ?? IsIsosceles(triangle);
    
    private static TriangleType? IsValid(Triangle triangle) => 
        !(triangle.SideA + triangle.SideB > triangle.SideC &&
          triangle.SideB + triangle.SideC > triangle.SideA &&
          triangle.SideA + triangle.SideC > triangle.SideB)
        ? TriangleType.Invalid
        : null;

    private static TriangleType? IsEquilateral(Triangle triangle) =>
        Math.Abs(triangle.SideA - triangle.SideB) < Tolerance &&
        Math.Abs(triangle.SideB - triangle.SideC) < Tolerance
            ? TriangleType.Equilateral
            : null;
    
    private static TriangleType? IsRight(Triangle triangle)
    {
        var aSquared = Math.Pow(triangle.SideA, 2);
        var bSquared = Math.Pow(triangle.SideB, 2);
        var cSquared = Math.Pow(triangle.SideC, 2);

        return Math.Abs(aSquared - (bSquared + cSquared)) < Tolerance ||
               Math.Abs(bSquared - (aSquared + cSquared)) < Tolerance ||
               Math.Abs(cSquared - (bSquared + aSquared)) < Tolerance
            ? TriangleType.Right
            : null;
    }

    private static TriangleType? IsIsosceles(Triangle triangle) =>
        Math.Abs(triangle.SideA - triangle.SideB) < Tolerance ||
        Math.Abs(triangle.SideA - triangle.SideC) < Tolerance ||
        Math.Abs(triangle.SideB - triangle.SideC) < Tolerance 
            ? TriangleType.Isosceles
            : TriangleType.Scalene;
}