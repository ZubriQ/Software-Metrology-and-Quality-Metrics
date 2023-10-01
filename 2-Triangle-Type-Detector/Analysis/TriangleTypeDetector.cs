namespace _2_Triangle_Type_Detector.Analysis;

public static class TriangleTypeDetector
{
    private const double Tolerance = 1e-10;

    public static TriangleType DetermineType(Triangle triangle)
    {
        if (IsValid(triangle))
        {
            return TriangleType.Invalid;
        }
        
        if (Math.Abs(triangle.SideA - triangle.SideB) < Tolerance &&
            Math.Abs(triangle.SideB - triangle.SideC) < Tolerance)
        {
            return TriangleType.Equilateral;
        }

        var aSquared = triangle.SideA * triangle.SideA;
        var bSquared = triangle.SideB * triangle.SideB;
        var cSquared = triangle.SideC * triangle.SideC;
        if (Math.Abs(aSquared - (bSquared + cSquared)) < Tolerance ||
            Math.Abs(bSquared - (aSquared + cSquared)) < Tolerance ||
            Math.Abs(cSquared - (bSquared + aSquared)) < Tolerance)
        {
            return TriangleType.Right;
        }

        if (Math.Abs(triangle.SideA - triangle.SideB) < Tolerance ||
            Math.Abs(triangle.SideA - triangle.SideC) < Tolerance ||
            Math.Abs(triangle.SideB - triangle.SideC) < Tolerance)
        {
            return TriangleType.Isosceles;
        }

        return TriangleType.Scalene;
    }

    private static bool IsValid(Triangle triangle)
    {
        return triangle.SideA + triangle.SideB > triangle.SideC &&
               triangle.SideB + triangle.SideC > triangle.SideA &&
               triangle.SideA + triangle.SideC > triangle.SideB;
    }
}