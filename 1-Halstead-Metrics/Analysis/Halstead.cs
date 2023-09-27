using _1_Halstead_Metrics.Analysis.Models;

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
            var oneDictionaryLength = _dictionary.GenerateDictionaryLength();
            sum += Math.Pow(oneDictionaryLength, 2) / _dictionary.SampleSize;
        }

        return sum;
    }

    #region  Calculation of final metric values
    private HalsteadResult CalculateHalsteadValues(double sum)
    {
        var statisticalValues = CalculateStatisticalValues(sum);
        var theoreticalValues = CalculateTheoreticalValues();
        var newExpectedSampleSize = Math.Pow(Constants.Quantile, 2) * statisticalValues.Dispersion / 0.01;

        return new HalsteadResult(statisticalValues, theoreticalValues, newExpectedSampleSize);
    }
    
    private MetricData CalculateStatisticalValues(double sum)
    {
        var expectedValue = (double)_dictionary.GeneratedNumberCount / _dictionary.SampleSize;
        var dispersion = sum - Math.Pow(expectedValue, 2);
        var measurementError = CalculateMeasurementError(dispersion, expectedValue);
        return new MetricData(expectedValue, dispersion, measurementError);
    }

    private MetricData CalculateTheoreticalValues()
    {
        var expectedValue = 0.9 * _dictionary.Size * Math.Log2(_dictionary.Size);
        var dispersion = Math.Pow(Math.PI, 2) * Math.Pow(_dictionary.Size, 2) / 6;
        var measurementError = CalculateMeasurementError(dispersion, expectedValue);
        return new MetricData(expectedValue, dispersion, measurementError);
    }

    private static double CalculateMeasurementError(double dispersion, double expectedValue) =>
        Math.Round(Math.Sqrt(dispersion) / expectedValue, 8);
    #endregion
}