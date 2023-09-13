using _1_Halstead_Metrics.Analysis;

namespace _1_Halstead_Metrics.AnalysisIO;

public static class HalsteadIO
{
    public static (int, int) InputParameters()
    {
        Console.WriteLine("Enter dictionary size:");
        var dictionarySize = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter sample size:");
        var sampleSize = int.Parse(Console.ReadLine()!);

        return (dictionarySize, sampleSize);
    }

    public static void PrintResultValues(HalsteadResult result)
    {
        Console.WriteLine();
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Average (M):\t{(int)(Math.Round(result.ExpectedValue, 3))}");
        Console.WriteLine($"Disperse (D):\t{(int)(Math.Round(result.Dispersion, 3))}");
        Console.ResetColor();

        Console.WriteLine($"Measurement error (d):\t{Math.Sqrt(result.Dispersion) / result.ExpectedValue}");

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"New sample size (N):\t{((int)result.NewExpectedSampleSize):### ### ##0}");
        Console.ResetColor();

        Console.WriteLine();
    }
}