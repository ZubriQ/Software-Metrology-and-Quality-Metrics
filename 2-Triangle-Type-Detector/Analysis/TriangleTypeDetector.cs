namespace _2_Triangle_Type_Detector.Analysis;

public static class TriangleTypeDetector
{
    private const double Tolerance = 1e-10;

    public static TriangleType? DetermineType(Triangle triangle)
    {
        return IsValid(triangle) ?? IsEquilateral(triangle) ?? IsRight(triangle) ?? IsIsosceles(triangle);
    }
    
    private static TriangleType? IsValid(Triangle triangle)
    {
        if (!(triangle.SideA + triangle.SideB > triangle.SideC &&
              triangle.SideB + triangle.SideC > triangle.SideA &&
              triangle.SideA + triangle.SideC > triangle.SideB))
        {
            return TriangleType.Invalid;
        }

        return null;
    }
    
    private static TriangleType? IsEquilateral(Triangle triangle)
    {
        if (Math.Abs(triangle.SideA - triangle.SideB) < Tolerance &&
            Math.Abs(triangle.SideB - triangle.SideC) < Tolerance)
        {
            return TriangleType.Equilateral;
        }

        return null;
    }
    
    private static TriangleType? IsRight(Triangle triangle)
    {
        var aSquared = triangle.SideA * triangle.SideA;
        var bSquared = triangle.SideB * triangle.SideB;
        var cSquared = triangle.SideC * triangle.SideC;

        if (Math.Abs(aSquared - (bSquared + cSquared)) < Tolerance ||
            Math.Abs(bSquared - (aSquared + cSquared)) < Tolerance ||
            Math.Abs(cSquared - (bSquared + aSquared)) < Tolerance)
        {
            return TriangleType.Right;
        }

        return null;
    }

    private static TriangleType? IsIsosceles(Triangle triangle)
    {
        if (Math.Abs(triangle.SideA - triangle.SideB) < Tolerance ||
            Math.Abs(triangle.SideA - triangle.SideC) < Tolerance ||
            Math.Abs(triangle.SideB - triangle.SideC) < Tolerance)
        {
            return TriangleType.Isosceles;
        }

        return TriangleType.Scalene;
    }
}