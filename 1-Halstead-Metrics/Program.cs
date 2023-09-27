using _1_Halstead_Metrics.Analysis;
using _1_Halstead_Metrics.AnalysisIO;
using _1_Halstead_Metrics.HypothesisAnalysis;

namespace _1_Halstead_Metrics;

internal static class Program
{
    private static readonly Halstead Halstead = new();
    private static readonly HypothesisAnalyzer Analyzer = new();
    
    private static void Main()
    {
        while (true)
        {
            Run();
        }
    }

    private static void Run()
    {
        DisplayInfo();
        GiveOptions();
    }

    private static void DisplayInfo()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nPress 'd' to test Halstead dictionary.");
        Console.WriteLine("Press 'h' to test Halstead hypothesis.");
        Console.WriteLine("Press 'q' to quit the programme.");
        Console.ResetColor();
    }
    
    private static void GiveOptions()
    {
        switch (Console.ReadKey().KeyChar)
        {
            case 'd':
                CalculateHalsteadDictionary();
                break;
            case 'h':
                CalculateHalsteadHypothesis();
                break;
            case 'q':
                Environment.Exit(0);
                break;
        }
    }

    private static void CalculateHalsteadHypothesis()
    {
        var input = HalsteadIO.InputHypothesisTestData();
        var hypothesisResult = Analyzer.Analyze(input);
        HalsteadIO.PrintHypothesisResultValues(hypothesisResult);
    }

    private static void CalculateHalsteadDictionary()
    {
        var (dictionarySize, sampleSize) = HalsteadIO.InputHalsteadDictionaryParameters();
        var halsteadResult = Halstead.GetMetricsData(dictionarySize, sampleSize);
        HalsteadIO.PrintHalsteadResultValues(halsteadResult);
    }
}