using System.Windows.Media;
using System.Windows.Shapes;

namespace _3_Lines_Shadow_Calculator.LineLibrary;

public static class FigureCreator
{
    public static Line CreateLineSegment(Models.Point from, Models.Point to) => new()
    {
        X1 = from.ActualX,
        Y1 = from.ActualY,
        X2 = to.ActualX,
        Y2 = to.ActualY,
        Stroke = new SolidColorBrush(Colors.CornflowerBlue),
        StrokeThickness = 1
    };
    
    public static Line CreateShadow(Models.Point from, Models.Point to) => new()
    {
        X1 = from.ActualX,
        Y1 = from.ActualY,
        X2 = to.ActualX,
        Y2 = to.ActualY,
        Stroke = new SolidColorBrush(Colors.Black),
        StrokeThickness = 3
    };
}