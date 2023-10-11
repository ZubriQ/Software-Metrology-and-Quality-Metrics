using System.Windows.Media;
using System.Windows.Shapes;

namespace _3_Lines_Shadow_Calculator.LineLibrary;

public static class LineCreator
{
    public static Line CreateLine(Models.Point startPoint, Models.Point endPoint) => new()
    {
        X1 = startPoint.X,
        Y1 = startPoint.Y,
        X2 = endPoint.X,
        Y2 = endPoint.Y,
        Stroke = new SolidColorBrush(Colors.CornflowerBlue),
        StrokeThickness = 1
    };
}