namespace _1_Halstead_Metrics;

internal class Program
{
    private static readonly Random Random = new();

    public static int PreviousSpotValue { get; set; } = -1;
    public static int CurrentSpotValue { get; set; } = -1;
    public static ulong GeneratedNumberCount { get; set; }

    public static int DictionarySize { get; set; }
    public static int InputedSampleSize { get; set; }

    public static double Sum { get; set; }
    public static double Dispersion { get; set; }
    public static double ExpectedValue { get; set; }
    public static double NewExpectedSampleSize { get; set; }
    
    private static void Main()
    {
        while (true)
        {
            InputParameters();
            CalculateSumOfSquaredSpotCounts();
            CalculateNewExpectedSampleSize();
            OutputValues();
            ResetParameters();
        }
    }
    
    private static void InputParameters()
    {
        Console.WriteLine("Enter dictionary size:");
        DictionarySize = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter sample size:");
        InputedSampleSize = int.Parse(Console.ReadLine()!);
    }

    private static void CalculateNewExpectedSampleSize()
    {
        ExpectedValue = GeneratedNumberCount / (double)InputedSampleSize;
        Dispersion = Sum - Math.Pow(ExpectedValue, 2);
        NewExpectedSampleSize = Math.Pow(Constants.Quantile, 2) * Dispersion / 0.01;
    }

    private static void CalculateSumOfSquaredSpotCounts()
    {
        for (int i = 0; i < InputedSampleSize; i++)
        {
            int arraySpotGenerateCount = 0;
            GenerateRandomNumberedArray(ref arraySpotGenerateCount);
            ResetPreviousValue();

            Sum += Math.Pow(arraySpotGenerateCount, 2) / InputedSampleSize;
        }
    }
    
    private static void GenerateRandomNumberedArray(ref int arraySpotGenerateCount)
    {
        int remainingArraySpots = DictionarySize;
        int[] dictionary = new int[DictionarySize];

        while (remainingArraySpots > 0)
        {
            int randomlySelectedArraySpot = Random.Next(0, DictionarySize);
            CurrentSpotValue = randomlySelectedArraySpot;
            if (CurrentSpotValue == PreviousSpotValue)
            {
                continue;
            }
            if (dictionary[CurrentSpotValue] == 0)
            {
                remainingArraySpots--;
            }

            arraySpotGenerateCount++;
            GeneratedNumberCount++;
            dictionary[CurrentSpotValue]++;
            PreviousSpotValue = CurrentSpotValue;
        }
    }

    private static void ResetPreviousValue() { PreviousSpotValue = 0; }

    private static void OutputValues()
    {
        Console.WriteLine();
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Average (M):\t{(int)(Math.Round(ExpectedValue, 3))}");
        Console.WriteLine($"Disperse (D):\t{(int)(Math.Round(Dispersion, 3))}");
        Console.ResetColor();

        Console.WriteLine($"Measurement error (d):\t{Math.Sqrt(Dispersion) / ExpectedValue}");

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"New sample size (N):\t{((int)NewExpectedSampleSize).ToString("### ### ##0")}");
        Console.ResetColor();

        Console.WriteLine();
    }
    
    private static void ResetParameters()
    {
        PreviousSpotValue = -1;
        CurrentSpotValue = -1;
        GeneratedNumberCount = 0;
        Dispersion = 0;
        ExpectedValue = 0;
        Sum = 0;
        NewExpectedSampleSize = 0;
    }
}