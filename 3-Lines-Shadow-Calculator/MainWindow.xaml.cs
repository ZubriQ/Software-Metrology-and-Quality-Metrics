using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3_Lines_Shadow_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //var lines = Canvas.Children.OfType<Line>().Where(l => l.Name != "LineAbscissa").ToArray();
        }

        private void ButtonAddLine_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                AddLineToCanvas();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers for the line coordinates.", "Invalid Input",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddLineToCanvas()
        {
            var startPoint = new Models.Point(TextBoxLineStartX.Text, TextBoxLineStartY.Text);
            var endPoint = new Models.Point(TextBoxLineEndX.Text, TextBoxLineEndY.Text);
            var line = CreateLine(startPoint, endPoint);
            Canvas.Children.Add(line);
        }

        private static Line CreateLine(Models.Point startPoint, Models.Point endPoint) => new()
        {
            X1 = startPoint.X,
            Y1 = startPoint.Y,
            X2 = endPoint.X,
            Y2 = endPoint.Y,
            Stroke = new SolidColorBrush(Colors.CornflowerBlue),
            StrokeThickness = 1
        };
    }
}