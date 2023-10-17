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
        var result = new List<Line>();
        
        var sortedLines = lines.OrderBy(l => l.From.X).ToArray();
        var visitedLines = new HashSet<LineInfo>();
        
        for (var i = 0; i < sortedLines.Length; i++)
        {
            if (!visitedLines.Add(sortedLines[i])) continue;

            var shadowFromX = sortedLines[i].From.X;
            var shadowToX = sortedLines[i].To.X;
            for (var j = 0; j < sortedLines.Length; j++)
            {
                if (sortedLines[i].From.X == sortedLines[j].From.X && sortedLines[i].To.X == sortedLines[j].To.X) continue;

                bool isVisited = false;
                if (shadowFromX > sortedLines[j].From.X && shadowFromX <= sortedLines[j].To.X)
                {
                    shadowFromX = sortedLines[j].From.X;
                    isVisited = true;
                }
                if (shadowToX < sortedLines[j].To.X && shadowToX >= sortedLines[j].From.X)
                {
                    shadowToX = sortedLines[j].To.X;
                    isVisited = true;
                }

                if (isVisited)
                {
                    visitedLines.Add(sortedLines[i]);
                }
            }
            
            var shadowLine = CreateShadow(
                new Point(shadowFromX.ToString(CultureInfo.CurrentCulture), "0"),
                new Point(shadowToX.ToString(CultureInfo.CurrentCulture), "0"));
            if (result.Any(line => line.X1 == shadowLine.X1 && line.X2 == shadowLine.X2)) continue;
            result.Add(shadowLine);
        }

        return result;
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
