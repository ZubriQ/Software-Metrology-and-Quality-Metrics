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
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nPress 'd' to test Halstead dictionary.");
        Console.WriteLine("Press 'h' to test Halstead hypothesis.");
        Console.WriteLine("Press 'q' to quit the programme.");
        Console.ResetColor();
        
        var option = Console.ReadKey();
        switch (option.KeyChar)
        {
            case 'd':
                var (dictionarySize, sampleSize) = HalsteadIO.InputHalsteadDictionaryParameters();
                var halsteadResult = Halstead.GetMetricsData(dictionarySize, sampleSize);
                HalsteadIO.PrintHalsteadResultValues(halsteadResult);
                break;
            case 'h':
                var input = HalsteadIO.InputHypothesisTestData();
                var hypothesisResult = Analyzer.Analyze(input);
                HalsteadIO.PrintHypothesisResultValues(hypothesisResult);
                break;
            case 'q':
                Environment.Exit(0);
                break;
        }
    }
}