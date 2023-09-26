namespace _1_Halstead_Metrics.Analysis;

public class Halstead
{
    private HalsteadDictionary _dictionary = null!;

    public HalsteadResult GetMetricsData(int dictionarySize, int sampleSize)
    {
        _dictionary = new HalsteadDictionary(dictionarySize, sampleSize);

        var programLength = CalculateSumOfDictionaryLengths();
        var halsteadValues = CalculateHalsteadValues(programLength);
        return halsteadValues;
    }

    private double CalculateSumOfDictionaryLengths()
    {
        double sum = 0;
        for (var i = 0; i < _dictionary.SampleSize; i++)
        {
            var oneDictionaryLength = _dictionary.GenerateSpecificDictionaryLength();
            sum += Math.Pow(oneDictionaryLength, 2) / _dictionary.SampleSize;
        }

        return sum;
    }
    
    private HalsteadResult CalculateHalsteadValues(double sum)
    {
        var expectedValue = (double)_dictionary.GeneratedNumberCount / _dictionary.SampleSize;
        var dispersion = sum - Math.Pow(expectedValue, 2);
        var measurementError = Math.Round(Math.Sqrt(dispersion) / expectedValue, 8);
        var statisticalValues = new MetricData(expectedValue, dispersion, measurementError);

        var expectedValue2 = 0.9 * _dictionary.Size * Math.Log2(_dictionary.Size);
        var dispersion2 = Math.Pow(Math.PI, 2) * Math.Pow(_dictionary.Size, 2) / 6;
        var measurementError2 = Math.Round(Math.Sqrt(dispersion2) / expectedValue2, 8);
        var theoreticalValues = new MetricData(expectedValue2, dispersion2, measurementError2);
        
        var newExpectedSampleSize = Math.Pow(Constants.Quantile, 2) * dispersion / 0.01;

        return new HalsteadResult(statisticalValues, theoreticalValues, newExpectedSampleSize);
    }
}