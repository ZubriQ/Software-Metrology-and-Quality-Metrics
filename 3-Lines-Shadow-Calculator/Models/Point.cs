using _3_Lines_Shadow_Calculator.LineLibrary;

namespace _3_Lines_Shadow_Calculator.Models;

public readonly struct Point
{
    public double X { get; }
    public double Y { get; }
    public double ActualX { get; }
    public double ActualY { get; }

    public Point(string x, string y)
    {
        X = double.Parse(x);
        Y = double.Parse(y);
        ActualX = Constants.CanvasCenterX + X;
        ActualY = Constants.CanvasCenterY + Y;
    }
}