using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _3_Lines_Shadow_Calculator;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ObservableCollection<Line> CanvasLines { get; }
    private Models.Point StartPoint => new(TextBoxLineStartX.Text, TextBoxLineStartY.Text);
    private Models.Point EndPoint => new(TextBoxLineEndX.Text, TextBoxLineEndY.Text);
        
    public MainWindow()
    {
        InitializeComponent();
        CanvasLines = new ObservableCollection<Line>();
        ListBoxLines.ItemsSource = CanvasLines;

        //var lines = Canvas.Children.OfType<Line>().Where(l => l.Name != "LineAbscissa").ToArray();
    }
    
    private void ButtonAddLine_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            AddLineToCanvas();
            ResetInput();
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
        CanvasLines.Add(line);
        Canvas.Children.Add(line);
    }
    
    private void ResetInput()
    {
        TextBoxLineStartX.Text = string.Empty;
        TextBoxLineStartY.Text = string.Empty;
        TextBoxLineEndX.Text = string.Empty;
        TextBoxLineEndY.Text = string.Empty;
    }
}