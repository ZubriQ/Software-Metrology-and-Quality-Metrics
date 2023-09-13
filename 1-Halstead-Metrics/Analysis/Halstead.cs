namespace _1_Halstead_Metrics.Analysis;

public class Halstead
{
    private readonly Random _random = new();
    private HalsteadArray? _array;

    public HalsteadResult GetMetricsData(int dictionarySize, int sampleSize)
    {
        _array = new HalsteadArray(dictionarySize, sampleSize);

        var sum = CalculateSumOfSquaredSpotCounts();
        var halsteadValues = EstimateNewHalsteadValues(sum);
        return halsteadValues;
    }

    private double CalculateSumOfSquaredSpotCounts()
    {
        double sum = 0;
        for (var i = 0; i < _array.SampleSize; i++)
        {
            var arraySpotGenerateCount = 0;
            GenerateRandomNumberedArray(ref arraySpotGenerateCount);

            sum += Math.Pow(arraySpotGenerateCount, 2) / _array.SampleSize;
        }

        return sum;
    }
    
    private void GenerateRandomNumberedArray(ref int arraySpotGenerateCount)
    {
        var remainingArraySpots = _array.Size;
        var dictionary = new int[_array.Size];

        while (remainingArraySpots > 0)
        {
            var randomlySelectedArraySpot = _random.Next(0, _array.Size);
            _array.CurrentSpotValue = randomlySelectedArraySpot;
            if (_array.CurrentSpotValue == _array.PreviousSpotValue)
            {
                continue;
            }
            if (dictionary[_array.CurrentSpotValue] == 0)
            {
                remainingArraySpots--;
            }

            arraySpotGenerateCount++;
            _array.GeneratedNumberCount++;
            dictionary[_array.CurrentSpotValue]++;
            _array.PreviousSpotValue = _array.CurrentSpotValue;
        }
    }
    
    private HalsteadResult EstimateNewHalsteadValues(double sum)
    {
        var expectedValue = (double)_array.GeneratedNumberCount / _array.SampleSize;
        var dispersion = sum - Math.Pow(expectedValue, 2);
        var newExpectedSampleSize = Math.Pow(Constants.Quantile, 2) * dispersion / 0.01;

        return new HalsteadResult(expectedValue, dispersion, newExpectedSampleSize);
    }
}