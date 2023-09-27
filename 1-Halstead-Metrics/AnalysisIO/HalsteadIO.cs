using _1_Halstead_Metrics.Analysis.Models;
using _1_Halstead_Metrics.HypothesisAnalysis.Models;

namespace _1_Halstead_Metrics.AnalysisIO;

public static class HalsteadIO
{
    public static (int, int) InputHalsteadDictionaryParameters()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nEnter dictionary size (for example, 16):");
        var dictionarySize = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter sample size (for example, 100):");
        var sampleSize = int.Parse(Console.ReadLine()!);
        Console.ResetColor();

        return (dictionarySize, sampleSize);
    }

    public static void PrintHalsteadResultValues(HalsteadResult result)
    {
        Console.WriteLine();
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(result);
        Console.ResetColor();
        
        Console.WriteLine();
    }

    public static HypothesisTestData InputHypothesisTestData()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nPlease, enter 4 values separated with spaces in 1 line: '(n1) (N1) (n2) (N2)'");
        Console.WriteLine("For example, 12 30 3 15");
        Console.ResetColor();
        
        var input = Console.ReadLine()!.Split().Select(int.Parse).ToArray();
        var operators = new DictionaryData(DistinctElementsCount: input[0], ElementsAppearanceCount: input[1]);
        var operands = new DictionaryData(DistinctElementsCount: input[2], ElementsAppearanceCount: input[3]);
        return new HypothesisTestData(operators, operands);
    }

    public static void PrintHypothesisResultValues(HypothesisResult result)
    {
        Console.WriteLine();
        
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(result);
        Console.ResetColor();
        
        Console.WriteLine();
    }
}