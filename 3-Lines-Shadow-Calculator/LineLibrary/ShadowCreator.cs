using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Media;
using System.Windows.Shapes;
using _3_Lines_Shadow_Calculator.Models;

namespace _3_Lines_Shadow_Calculator.LineLibrary;

public static class ShadowCreator
{
    private static int _instancesCount;
    
    public static List<Line> Create(ICollection<LineInfo> lines)
    {
        var sortedLines = lines.OrderBy(l => l.From.X).ToList();
        
        // TODO: shadows algorithm
        
        return lines
            .Select(line => CreateShadow(
                new Point(line.From.X.ToString(CultureInfo.CurrentCulture), "0"), 
                new Point(line.To.X.ToString(CultureInfo.CurrentCulture), "0")))
            .ToList();
    }

    private static Line CreateShadow(Point from, Point to) => new()
    {
        X1 = from.ActualX,
        Y1 = from.ActualY,
        X2 = to.ActualX,
        Y2 = to.ActualY,
        Uid = "Shadow" + ++_instancesCount,
        Stroke = new SolidColorBrush(Colors.Black),
        StrokeThickness = 3
    };

    private static double CalculateDistance(Point p1, Point p2)
    {
        var xDistance = p2.X - p1.X;
        var yDistance = p2.Y - p1.Y;

        return Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
    }
}
