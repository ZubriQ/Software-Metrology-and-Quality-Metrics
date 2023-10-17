using System.Windows.Media;
using System.Windows.Shapes;

namespace _3_Lines_Shadow_Calculator.LineLibrary;

public static class LineSegmentCreator
{
    private static int _instancesCount;

    public static Line CreateLineSegment(Models.Point from, Models.Point to) => new()
    {
        X1 = from.ActualX,
        Y1 = from.ActualY,
        X2 = to.ActualX,
        Y2 = to.ActualY,
        Uid = "LineSegment" + ++_instancesCount,
        Stroke = new SolidColorBrush(Colors.CornflowerBlue),
        StrokeThickness = 1
    };
    
    public static Line CreateAbscissa() => new()
    {
        X1 = 0,
        Y1 = 250,
        X2 = 500,
        Y2 = 250,
        Stroke = Brushes.CadetBlue,
        StrokeThickness = 1,
    };

    public static Line CreateOrdinate() => new()
    {
        X1 = 250,
        Y1 = 500,
        X2 = 250,
        Y2 = 0,
        Stroke = Brushes.CadetBlue,
        StrokeThickness = 1,
    };
}