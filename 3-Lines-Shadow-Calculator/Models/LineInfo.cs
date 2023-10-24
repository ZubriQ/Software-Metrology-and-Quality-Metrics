namespace _3_Lines_Shadow_Calculator.Models;

public class LineInfo
{
    public Point From { get; }
    public Point To { get; }
    public double Length { get; }
    
    public LineInfo(Point from, Point to)
    {
        if (from.X > to.X)
        {
            From = to;
            To = from;
        }
        else
        {
            From = from;
            To = to;
        }
    }

    public LineInfo(Point from, Point to, double length)
    {
        if (from.X > to.X)
        {
            From = to;
            To = from;
        }
        else
        {
            From = from;
            To = to;
        }
        Length = length;
    }
}