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
using _3_Lines_Shadow_Calculator.LineLibrary;

namespace _3_Lines_Shadow_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.Point EndPoint => new(TextBoxLineEndX.Text, TextBoxLineEndY.Text);
        private Models.Point StartPoint => new(TextBoxLineStartX.Text, TextBoxLineStartY.Text);

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
            var line = LineCreator.CreateLine(StartPoint, EndPoint);
            Canvas.Children.Add(line);
        }
    }
}