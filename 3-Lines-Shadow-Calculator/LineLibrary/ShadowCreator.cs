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

    private static List<Line> _shadows = null!;
    private static List<double> _shadowsLengths = null!;

    private static double _shadowFromX;
    private static double _shadowToX;

    /// <summary>
    /// Creates shadows that based on lines.
    /// </summary>
    /// <param name="lines">Lines to shadow.</param>
    /// <returns>Shadows of the lines and their lengths.</returns>
    public static (List<Line>, List<double>) Create(IEnumerable<LineInfo> lines)
    {
        _shadows = new List<Line>();
        _shadowsLengths = new List<double>();
        
        var sortedLines = lines.OrderBy(l => l.From.X).ToArray();
        var checkedLines = new HashSet<LineInfo>();
        
        foreach (var sortedLine in sortedLines)
        {
            if (!checkedLines.Add(sortedLine))
            {
                continue;
            }

            _shadowFromX = sortedLine.From.X;
            _shadowToX = sortedLine.To.X;
            CheckLines(sortedLines, checkedLines, sortedLine);
            AddShadow(_shadowFromX, _shadowToX);
        }

        return (_shadows, _shadowsLengths);
    }

    private static void CheckLines(LineInfo[] sortedLines, HashSet<LineInfo> checkedLines, LineInfo sortedLine)
    {
        foreach (var line in sortedLines)
        {
            if (IsSameLine(sortedLine, line))
            {
                continue;
            }

            CheckLine(checkedLines, line);
        }
    }

    private static bool IsSameLine(LineInfo sortedLine, LineInfo line) =>
        Math.Abs(sortedLine.From.X - line.From.X) < Constants.Tolerance &&
        Math.Abs(sortedLine.To.X - line.To.X) < Constants.Tolerance;

    private static void CheckLine(ISet<LineInfo> checkedLines, LineInfo line)
    {
        var isVisited = false;
        if (_shadowFromX >= line.From.X && _shadowFromX <= line.To.X)
        {
            _shadowFromX = line.From.X;
            isVisited = true;
        }
        if (_shadowToX <= line.To.X && _shadowToX >= line.From.X)
        {
            _shadowToX = line.To.X;
            isVisited = true;
        }

        if (isVisited)
        {
            checkedLines.Add(line);
        }
    }

    private static void AddShadow(double shadowFromX, double shadowToX)
    {
        var shadowLine = CreateShadow(
            new Point(shadowFromX.ToString(CultureInfo.CurrentCulture), "0"),
            new Point(shadowToX.ToString(CultureInfo.CurrentCulture), "0"));
        if (IsAlreadyExist(shadowLine))
        {
            return;
        }

        _shadows.Add(shadowLine);
        _shadowsLengths.Add(CalculateDistance(shadowLine));
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

    private static bool IsAlreadyExist(Line shadowLine) =>
        _shadows.Any(line => Math.Abs(line.X1 - shadowLine.X1) < Constants.Tolerance ||
                             Math.Abs(line.X2 - shadowLine.X2) < Constants.Tolerance);

    private static double CalculateDistance(Line shadow)
    {
        var xDistance = shadow.X2 - shadow.X1;
        var yDistance = shadow.Y2 - shadow.Y1;

        return Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
    }
}