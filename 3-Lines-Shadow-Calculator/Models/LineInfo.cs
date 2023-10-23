namespace _3_Lines_Shadow_Calculator.Models;

public class LineInfo
{
    public Point From { get; set; }
    public Point To { get; set; }
    public double Length { get; set; }
    
    public LineInfo(Point from, Point to)
    {
        From = from;
        To = to;
    }

    public LineInfo(Point from, Point to, double length)
    {
        From = from;
        To = to;
        Length = length;
    }
}