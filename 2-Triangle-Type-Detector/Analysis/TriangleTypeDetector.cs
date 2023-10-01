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
        
        if (IsEquilateral(triangle))
        {
            return TriangleType.Equilateral;
        }
        
        if (IsRight(triangle))
        {
            return TriangleType.Right;
        }

        return IsIsosceles(triangle) ? TriangleType.Isosceles : TriangleType.Scalene;
    }

    private static bool IsIsosceles(Triangle triangle)
    {
        return Math.Abs(triangle.SideA - triangle.SideB) < Tolerance ||
               Math.Abs(triangle.SideA - triangle.SideC) < Tolerance ||
               Math.Abs(triangle.SideB - triangle.SideC) < Tolerance;
    }

    private static bool IsRight(Triangle triangle)
    {
        var aSquared = triangle.SideA * triangle.SideA;
        var bSquared = triangle.SideB * triangle.SideB;
        var cSquared = triangle.SideC * triangle.SideC;
        
        return Math.Abs(aSquared - (bSquared + cSquared)) < Tolerance ||
               Math.Abs(bSquared - (aSquared + cSquared)) < Tolerance ||
               Math.Abs(cSquared - (bSquared + aSquared)) < Tolerance;
    }

    private static bool IsEquilateral(Triangle triangle)
    {
        return Math.Abs(triangle.SideA - triangle.SideB) < Tolerance &&
               Math.Abs(triangle.SideB - triangle.SideC) < Tolerance;
    }

    private static bool IsValid(Triangle triangle)
    {
        return triangle.SideA + triangle.SideB > triangle.SideC &&
               triangle.SideB + triangle.SideC > triangle.SideA &&
               triangle.SideA + triangle.SideC > triangle.SideB;
    }
}