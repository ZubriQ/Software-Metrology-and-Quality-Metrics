using _1_Halstead_Metrics.Analysis;
using _1_Halstead_Metrics.AnalysisIO;

namespace _1_Halstead_Metrics;

internal static class Program
{
    private static void Main()
    {
        var halstead = new Halstead();
        
        while (true)
        {
            var (dictionarySize, sampleSize) = HalsteadIO.InputParameters();
            var result = halstead.GetMetricsData(dictionarySize, sampleSize);
            HalsteadIO.PrintResultValues(result);
        }
    }
}