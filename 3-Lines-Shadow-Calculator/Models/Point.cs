namespace _3_Lines_Shadow_Calculator.Models;

public struct Point
{
    public double X { get; }
    public double Y { get; }

    public Point(string x, string y)
    {
        X = double.Parse(x);
        Y = double.Parse(y);
    }
}