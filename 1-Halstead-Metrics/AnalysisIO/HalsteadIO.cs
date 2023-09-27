using _1_Halstead_Metrics.Analysis;

namespace _1_Halstead_Metrics.AnalysisIO;

public static class HalsteadIO
{
    public static (int, int) InputParameters()
    {
        Console.WriteLine("Enter dictionary size (for example, 16):");
        var dictionarySize = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter sample size (for example, 100):");
        var sampleSize = int.Parse(Console.ReadLine()!);

        return (dictionarySize, sampleSize);
    }

    public static void PrintResultValues(HalsteadResult result)
    {
        Console.WriteLine();
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(result);
        Console.ResetColor();
        
        Console.WriteLine();
    }
}