namespace _1_Halstead_Metrics;

public class Halstead
{
    private readonly Random _random = new();

    public int PreviousSpotValue { get; set; }
    public int CurrentSpotValue { get; set; }
    public ulong GeneratedNumberCount { get; set; }

    public int DictionarySize { get; set; }
    public int SampleSize { get; set; }

    /// <summary>
    /// Calculates Dispersion, Expected value and the next expected sample size for a dictionary.
    /// </summary>
    public HalsteadResult GetMetricsData(int dictionarySize, int sampleSize)
    {
        InitializeParameters();
        
        DictionarySize = dictionarySize;
        SampleSize = sampleSize;

        var sum = CalculateSumOfSquaredSpotCounts();
        return CalculateNewHalsteadValues(sum);
    }
    
    private void InitializeParameters()
    {
        PreviousSpotValue = -1;
        CurrentSpotValue = -1;
        GeneratedNumberCount = 0;
    }

    private double CalculateSumOfSquaredSpotCounts()
    {
        double sum = 0;
        for (var i = 0; i < SampleSize; i++)
        {
            var arraySpotGenerateCount = 0;
            GenerateRandomNumberedArray(ref arraySpotGenerateCount);
            ResetPreviousValue();

            sum += Math.Pow(arraySpotGenerateCount, 2) / SampleSize;
        }

        return sum;
    }
    
    private void GenerateRandomNumberedArray(ref int arraySpotGenerateCount)
    {
        var remainingArraySpots = DictionarySize;
        var dictionary = new int[DictionarySize];

        while (remainingArraySpots > 0)
        {
            var randomlySelectedArraySpot = _random.Next(0, DictionarySize);
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
    
    private void ResetPreviousValue() { PreviousSpotValue = 0; }
    
    private HalsteadResult CalculateNewHalsteadValues(double sum)
    {
        var expectedValue = (double) GeneratedNumberCount / SampleSize;
        var dispersion = sum - Math.Pow(expectedValue, 2);
        var newExpectedSampleSize = Math.Pow(Constants.Quantile, 2) * dispersion / 0.01;
        
        return new HalsteadResult
        {
            ExpectedValue = expectedValue,
            Dispersion = dispersion,
            NewExpectedSampleSize = newExpectedSampleSize,
        };
    }
}